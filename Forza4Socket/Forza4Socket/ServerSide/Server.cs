using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using Forza4Socket.ClientSide;
using Forza4Socket.Game;

namespace Forza4Socket.ServerSide
{
    internal class Server
    {
        private byte[] Buffer;
        private List<Socket> ClientSockets;
        private Socket ServerSocket;
        private Grid Grid;
        private List<Player> Players;
        private List<Player> ActivePlayers;
        private int TurnPlayerId = -1;
        const int REQUIRED_PLAYERS = 2;

        public static int KNOWN_PORT = 11000;

        public Server()
        {
            Buffer = new byte[1024]; // TODO: use multiple buffers
            ClientSockets = new List<Socket>();
            Players = new List<Player>();
            ActivePlayers = new List<Player>();
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Grid = new Grid();
        }

        public void Setup()
        {
            try
            {
                Console.WriteLine("Server: Setting up server...");
                ServerSocket.Bind(new IPEndPoint(IPAddress.Any, KNOWN_PORT));
                ServerSocket.Listen(0);

                // tells the server what to do when starting to accept a client connection
                ServerSocket.BeginAccept(new AsyncCallback(OnConnectionTrial), null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void OnConnectionTrial(IAsyncResult asyncResult)
        {
            try
            {
                // accept connection
                Socket socket = ServerSocket.EndAccept(asyncResult);
                Console.WriteLine("Server: A client has been connected");

                ClientSockets.Add(socket);
                // listen for possible incoming data
                socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), socket);

                // continue to listen to incoming connections
                ServerSocket.BeginAccept(new AsyncCallback(OnConnectionTrial), null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void OnDataReceived(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState!;
            try
            {
                int receivedBytes = socket.EndReceive(asyncResult);
                byte[] dataBuffer = new byte[receivedBytes];
                Array.Copy(Buffer, dataBuffer, receivedBytes);

                // check if client has been disconnected
                if (receivedBytes == 0)
                {
                    HandleDisconnectedClient(socket);
                    return;
                }

                ClientRequest? req = GetDataFromBytes(dataBuffer);
                if (req != null)
                {
                    // tell all clients the state of the game
                    foreach (Socket client in ClientSockets)
                    {
                        ServerResponse res = HandleRequest(req, socket, client);
                        SendDataToClient(client, res);
                    }
                }

                // continue to listen to incoming messages
                socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), socket);
            }
            catch (Exception ex)
            {
                if (ex is SocketException)
                {
                    HandleDisconnectedClient(socket);
                }
                Console.WriteLine(ex.ToString());
            }
        }

        private ClientRequest? GetDataFromBytes(byte[] bytes)
        {
            string rawString = Encoding.UTF8.GetString(bytes);

            if (rawString.Length > 0)
            {
                ClientRequest req = JsonSerializer.Deserialize<ClientRequest>(rawString)!;

                Console.WriteLine("Server: Data received " + rawString);

                return req;
            }

            return null;
        }

        private void SendDataToClient(Socket socket, ServerResponse response)
        {
            try
            {
                string json = JsonSerializer.Serialize(response);
                byte[] data = Encoding.UTF8.GetBytes(json);

                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnDataSent), socket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                if (ex is SocketException)
                {
                    HandleDisconnectedClient(socket);
                }
            }
        }

        private void OnDataSent(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState!;
            try
            {
                socket.EndSend(asyncResult);

                Console.WriteLine("Server: Data sent to client");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                if (ex is SocketException)
                {
                    HandleDisconnectedClient(socket);
                }
            }
        }

        private void HandleDisconnectedClient(Socket socket)
        {
            try
            {
                Console.WriteLine("Server: A client disconnected");

                int id = ClientSockets.FindIndex((s) => socket == s);
                if (id != -1)
                {
                    ClientSockets.RemoveAt(id);
                    Players.RemoveAll((p) => p.Id == id);
                    ActivePlayers.RemoveAll((p) => p.Id == id);
                }

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private ServerResponse HandleRequest(ClientRequest req, Socket senderClient, Socket receiverClient)
        {
            int senderId = ClientSockets.FindIndex((s) => s == senderClient);
            int senderPlayerIndex = Players.FindIndex((player) => player.Id == senderId);

            int receiverId = ClientSockets.FindIndex((s) => s == receiverClient);
            int receiverPlayerIndex = Players.FindIndex((p) => p.Id == receiverId);

            if (req.CanPlayGame == true)
            {
                // create new player only if it's not already in list and if there's a valid socket associated
                if (senderId != -1 && senderPlayerIndex == -1)
                {
                    Player newPlayer = new Player()
                    {
                        Id = senderId,
                        GameMode = ActivePlayers.Count < REQUIRED_PLAYERS ? GameMode.Player : GameMode.Spectator,
                        Username = req.Username != null ? req.Username : $"Guest-{senderId}"
                    };

                    Players.Add(newPlayer);
                    if (receiverClient == senderClient) receiverPlayerIndex = Players.Count - 1;

                    if (ActivePlayers.Count < REQUIRED_PLAYERS) ActivePlayers.Add(newPlayer);
                }
            }

            bool isValidCell = false;
            if (req.SelectedCell != null)
            {
                isValidCell = Grid.InsertPawn(senderId, req.SelectedCell.Row, req.SelectedCell.Column);
                ChangeTurnPlayer();
            }

            int winningPlayerId = -1;
            if (req.Disconnection == true)
            {
                HandleDisconnectedClient(senderClient);
            }

            if (ActivePlayers.Count == 1)
            {
                winningPlayerId = ActivePlayers[0].Id;
            }
            else if (ActivePlayers.Count == REQUIRED_PLAYERS)
            {
                winningPlayerId = ActivePlayers.FindIndex((p) => Grid.CheckVictory(p.Id));
            }

            ServerResponse res = new ServerResponse()
            {
                TurnPlayer = TurnPlayerId,
                Players = Players,
                GameStarted = Players.Count == REQUIRED_PLAYERS,
                UpdatedGrid = Grid,
                WinningPlayer = winningPlayerId > -1 ? winningPlayerId : null,
                Player = receiverPlayerIndex > -1 ? Players[receiverPlayerIndex] : null,
                IsGameOver = winningPlayerId > -1,
                IsCellSelectable = winningPlayerId > -1,
            };

            return res;
        }

        public void ChangeTurnPlayer()
        {
            if (ActivePlayers.Count != REQUIRED_PLAYERS) return;

            if (ActivePlayers[0].Id == TurnPlayerId)
            {
                TurnPlayerId = ActivePlayers[1].Id;
            }
            else
            {
                TurnPlayerId = ActivePlayers[0].Id;
            }
        }

        public void CloseAllConnections()
        {
            try
            {
                foreach (Socket socket in ClientSockets)
                {
                    if (socket.Connected)
                    {
                        // a zero bytes response will be sent to all clients when closing the socket
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }
                }
                ClientSockets.Clear();
                Players.Clear();
                ActivePlayers.Clear();
                Grid.ClearGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

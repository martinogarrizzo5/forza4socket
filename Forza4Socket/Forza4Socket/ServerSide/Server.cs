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
        private List<ConnectedSocket> ClientSockets;
        private Socket ServerSocket;
        private Forza4 Forza4;
        private List<Player> Players;
        private List<Player> ActivePlayers;
        private int TurnPlayerId = -1;
        private int WinningPlayerId = -1;
        private bool InvalidCellClicked = false;
        const int REQUIRED_PLAYERS = 2;
        int nextId = 1;

        public static int KNOWN_PORT = 11000;

        public Server()
        {
            Buffer = new byte[1024]; // TODO: use multiple buffers
            ClientSockets = new List<ConnectedSocket>();
            Players = new List<Player>();
            ActivePlayers = new List<Player>();
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Forza4 = new Forza4();
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

                ClientSockets.Add(new ConnectedSocket(socket));
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
                    HandleRequest(req, socket);

                    // tell all clients the new state of the game
                    foreach (ConnectedSocket client in ClientSockets)
                    {
                        ServerResponse res = GenerateResponse(req, socket, client.Socket);
                        SendDataToClient(client.Socket, res);
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

                int index = ClientSockets.FindIndex((s) => socket == s.Socket);
                if (index != -1)
                {
                    ConnectedSocket disconnectedSocket = ClientSockets[index];
                    ClientSockets.RemoveAt(index);
                    Players.RemoveAll((p) => p == disconnectedSocket.Player);
                    ActivePlayers.RemoveAll((p) => p == disconnectedSocket.Player);
                }

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void HandleRequest(ClientRequest req, Socket requestSender)
        {
            int senderIndex = ClientSockets.FindIndex((s) => s.Socket == requestSender);
            if (senderIndex == -1) return;

            ConnectedSocket sender = ClientSockets[senderIndex];

            // handle the case in which a player wants to start playing or specting the current game
            if (req.CanPlayGame == true)
            {
                // create new player
                if (sender.Player == null)
                {
                    Player newPlayer = new Player()
                    {
                        Id = nextId,
                        GameMode = ActivePlayers.Count < REQUIRED_PLAYERS ? GameMode.Player : GameMode.Spectator,
                        Username = req.Username != null && req.Username != "" ? req.Username : $"Guest-{nextId}"
                    };
                    nextId++;

                    Players.Add(newPlayer);
                    sender.Player = newPlayer;

                    if (ActivePlayers.Count < REQUIRED_PLAYERS)
                    {
                        ActivePlayers.Add(newPlayer);
                        // start game
                        if (ActivePlayers.Count == REQUIRED_PLAYERS)
                        {
                            TurnPlayerId = ActivePlayers[0].Id;
                        }
                    };
                }
            }

            Player? player = sender.Player;

            if (req.SelectedCell != null && ActivePlayers.Count == REQUIRED_PLAYERS && player != null && TurnPlayerId == player.Id
                && player.GameMode == GameMode.Player && WinningPlayerId == -1)
            {
                bool isValidCell = Forza4.InsertPawn(player.Id, req.SelectedCell.Row, req.SelectedCell.Column);
                if (isValidCell)
                {
                    ChangeTurnPlayer();
                    InvalidCellClicked = false;
                }
                else
                {
                    InvalidCellClicked = true;
                }
            }

            if (req.Disconnection == true)
            {
                HandleDisconnectedClient(requestSender);
            }

            if (ActivePlayers.Count == REQUIRED_PLAYERS)
            {
                int winningPlayerIndex = ActivePlayers.FindIndex((p) => Forza4.CheckVictory(p.Id));
                if (winningPlayerIndex != -1)
                {
                    WinningPlayerId = ActivePlayers[winningPlayerIndex].Id;
                }
            }

        }

        private ServerResponse? GenerateResponse(ClientRequest req, Socket requestSender, Socket receiverClient)
        {
            int receiverIndex = ClientSockets.FindIndex((s) => s.Socket == receiverClient);
            if (receiverIndex == -1) return null;

            Player? receiverPlayer = ClientSockets[receiverIndex].Player;

            ServerResponse res = new ServerResponse()
            {
                TurnPlayerId = TurnPlayerId,
                Players = Players,
                GameStarted = ActivePlayers.Count == REQUIRED_PLAYERS,
                Grid = Forza4.GameGrid,
                WinningPlayerId = WinningPlayerId > -1 ? WinningPlayerId : null,
                Player = receiverPlayer != null ? receiverPlayer : null,
                IsGameOver = WinningPlayerId > -1,
                IsCellSelectedInvalid = InvalidCellClicked,
                LastSelectedCell = req.SelectedCell,
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
                foreach (ConnectedSocket client in ClientSockets)
                {
                    if (client.Socket.Connected)
                    {
                        // a zero bytes response will be sent to all clients when closing the socket
                        client.Socket.Shutdown(SocketShutdown.Both);
                        client.Socket.Close();
                    }
                }
                ClientSockets.Clear();
                Players.Clear();
                ActivePlayers.Clear();
                Forza4.ClearGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

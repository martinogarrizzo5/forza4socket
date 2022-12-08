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
        private int TurnPlayer = -1;
        const int MAX_PLAYERS = 2;

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
            try
            {
                Socket socket = (Socket)asyncResult.AsyncState!;

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
                    ServerResponse res = HandleRequest(req, socket);

                    // tell all clients the state of the game
                    foreach (Socket client in ClientSockets)
                    {
                        SendDataToClient(client, res);
                    }
                }

                // continue to listen to incoming messages
                socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), socket);
            }
            catch (Exception ex)
            {
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

                // remove socket if unavailable to receive data
                ClientSockets.Remove(socket);
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
                ClientSockets.Remove(socket);
            }
        }

        private void HandleDisconnectedClient(Socket socket)
        {
            try
            {
                Console.WriteLine("Server: A client disconnected");

                int id = ClientSockets.FindIndex((s) => socket == s);
                ClientSockets.RemoveAt(id);
                Players.RemoveAll((p) => p.Id == id);

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private ServerResponse HandleRequest(ClientRequest req, Socket socket)
        {
            int id = ClientSockets.FindIndex((s) => s == socket);
            int player = Players.FindIndex((player) => player.Id == id);

            if (req.CanPlayGame == true)
            {
                // create new player only if it's not already in list and if there's a valid socket associated
                if (id != -1 && player == -1)
                {
                    Player newPlayer = new Player()
                    {
                        Id = id,
                        GameMode = ActivePlayers.Count < MAX_PLAYERS ? GameMode.Player : GameMode.Spectator,
                        Username = req.Username != null ? req.Username : $"Guest-{id}"
                    };

                    Players.Add(newPlayer);
                    if (ActivePlayers.Count < MAX_PLAYERS) ActivePlayers.Add(newPlayer);
                }
            }

            if (req.SelectedCell != null)
            {

            }

            if (req.Disconnection == true)
            {
                ClientSockets.RemoveAt(id);
                Players.RemoveAll((player) => player.Id == id);
                ActivePlayers.RemoveAll((player) => player.Id == id);
            }

            ServerResponse res = new ServerResponse()
            {
                TurnPlayer = 1,
                Players = Players,
            };

            return res;
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using Forza4Socket.ClientSide;

namespace Forza4Socket.ServerSide
{
    internal class Server
    {
        private byte[] Buffer = new byte[1024];
        private List<Socket> ClientSockets = new List<Socket>();
        private Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static int KNOWN_PORT = 11000;

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
                    ServerResponse res = HandleRequest(req);

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
            }
        }

        private void OnDataSent(IAsyncResult asyncResult)
        {
            try
            {
                Socket socket = (Socket)asyncResult.AsyncState!;
                socket.EndSend(asyncResult);

                Console.WriteLine("Server: Data sent to client");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void HandleDisconnectedClient(Socket socket)
        {
            try
            {
                Console.WriteLine("Server: A client disconnected");
                ClientSockets.Remove(socket);
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private ServerResponse HandleRequest(ClientRequest req)
        {
            ServerResponse res = new ServerResponse()
            {
                TurnPlayer = 1,
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
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

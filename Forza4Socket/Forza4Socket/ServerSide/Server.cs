using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Forza4Socket.ClientSide;

namespace Forza4Socket.ServerSide
{
    internal class Server
    {
        private byte[] buffer = new byte[1024];
        private List<Socket> clientSockets = new List<Socket>();
        private Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static int knownPort = 11000;

        public void Setup()
        {
            Console.WriteLine("Server: Setting up server...");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, knownPort));
            serverSocket.Listen(5);

            // tells the server what to do when starting to accept a client connection
            serverSocket.BeginAccept(new AsyncCallback(OnConnectionTrial), null);
        }

        private void OnConnectionTrial(IAsyncResult asyncResult)
        {
            // accept connection
            Socket socket = serverSocket.EndAccept(asyncResult);
            Console.WriteLine("Server: A client has been connected");

            clientSockets.Add(socket);
            // listen for possible incoming data
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), socket);

            // continue to listen to incoming connections
            serverSocket.BeginAccept(new AsyncCallback(OnConnectionTrial), null);
        }

        private void OnDataReceived(IAsyncResult asyncResult)
        {
            Socket socket = asyncResult.AsyncState as Socket;

            int receivedBytes = socket.EndReceive(asyncResult);
            byte[] dataBuffer = new byte[receivedBytes];
            Array.Copy(buffer, dataBuffer, receivedBytes);

            ClientRequest req = GetDataFromBytes(dataBuffer);
            Console.WriteLine("Server: Data received");
            Console.WriteLine("Server: Cell Row " + req.SelectedCell.Row);

            // tell all clients the state of the game
            foreach(Socket client in clientSockets)
            {
                ServerResponse res = new ServerResponse()
                {
                    TurnPlayer = 1,
                };

                SendDataToClient(client, res);
            }

            // continue to listen to incoming messages
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), socket);
        }

        private ClientRequest GetDataFromBytes(byte[] bytes)
        {
            string rawString = Encoding.UTF8.GetString(bytes);
            ClientRequest req = JsonSerializer.Deserialize<ClientRequest>(rawString);

            return req;
        }

        private void SendDataToClient(Socket socket, ServerResponse response)
        {
            string json = JsonSerializer.Serialize(response);
            byte[] data = Encoding.UTF8.GetBytes(json);

            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnDataSent), socket);
        }

        private void OnDataSent(IAsyncResult asyncResult)
        {
            Socket socket = asyncResult.AsyncState as Socket;
            socket.EndSend(asyncResult);

            Console.WriteLine("Data sent to client");
        }
    }
}

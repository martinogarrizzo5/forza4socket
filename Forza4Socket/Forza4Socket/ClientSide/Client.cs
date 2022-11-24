using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Forza4Socket.ServerSide;

namespace Forza4Socket.ClientSide
{
    internal class Client
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void ConnectToServer()
        {
            int attempts = 0;

            while (!socket.Connected)
            {
                try
                {
                    attempts++;
                    socket.Connect(new IPEndPoint(IPAddress.Loopback, Server.knownPort));
                }
                catch (SocketException)
                {
                    Console.WriteLine("Client: Connetion attempt: " + attempts.ToString());
                }
            }

            Console.WriteLine("Client: Connected");
        }

        public void SendDataToServer(ClientRequest req)
        {
            string json = JsonSerializer.Serialize(req);
            byte[] rawData = Encoding.UTF8.GetBytes(json);
            socket.Send(rawData);

            Console.WriteLine("Client: data sent to server");

            ListenForIncomingData();
        }

        public void ListenForIncomingData()
        {
            // listen to incoming data after sending request
            byte[] receivedBuffer = new byte[1024];
            int receivedBytes = socket.Receive(receivedBuffer);
            byte[] rawData = new byte[receivedBytes];
            Array.Copy(receivedBuffer, rawData, receivedBytes);

            string data = Encoding.UTF8.GetString(rawData);
            ServerResponse res = JsonSerializer.Deserialize<ServerResponse>(data);

            Console.WriteLine("Client: data received");
            Console.WriteLine("Turn player index " + res.TurnPlayer);
        }
    }
}

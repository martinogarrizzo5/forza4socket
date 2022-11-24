using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forza4Socket.Client
{
    internal class Client
    {
        Socket socket;

        public void Start()
        {
            byte[] bytes = new byte[1024];

            try
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

                socket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void ConnectToServer()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                int knownPort = 11000;
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, knownPort);
                socket.Connect(remoteEP);

            }
            catch (ArgumentException ane)
            {
                Console.WriteLine("ArgumentNullException: {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException: {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexptected Exception: {0}", e.ToString());
            }
        }

        public void SendDataToServer(ClientRequest req)
        {
            string json = JsonSerializer.Serialize(req);
            byte[] rawData = Encoding.Unicode.GetBytes(json);
            socket.Send(rawData);

        }
    }
}

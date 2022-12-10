using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Forza4Socket.ServerSide;
using Forza4Socket.Network;

namespace Forza4Socket.ClientSide
{
    internal class Client
    {
        private Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private byte[] Buffer = new byte[1024];
        private Action<ServerResponse> ActionOnDataReceived;
        private Action<IPAddress> ActionOnDeviceDiscovered;
        private Action ActionOnServerConnectionAccepted;
        private Action<List<IPAddress>> ActionOnDiscoverFinished;
        public string localNetworkAddress = "192.168.1.0";

        public Client(Action<ServerResponse> onDataReceived, Action<IPAddress> onDeviceDiscovered, Action onConnectionAccepted, Action<List<IPAddress>> onDiscoverFinished)
        {
            ActionOnDataReceived = onDataReceived;
            ActionOnDeviceDiscovered = onDeviceDiscovered;
            ActionOnServerConnectionAccepted = onConnectionAccepted;
            ActionOnDiscoverFinished = onDiscoverFinished;
        }

        public void ChangeLocalNetworkAddress(string address)
        {
            localNetworkAddress = address;
        }

        public bool IsConnected()
        {
            return Socket.Connected;
        }

        public void ConnectToServer(IPAddress ipAddress)
        {
            try
            {
                Socket.BeginConnect(new IPEndPoint(ipAddress, Server.KNOWN_PORT),
                    new AsyncCallback(OnConnectionResult), null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (Socket.Connected)
                {
                    // a zero bytes request will be sent when closing the socket
                    Socket.Shutdown(SocketShutdown.Both);
                    Socket.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void SendDataToServer(ClientRequest req)
        {
            try
            {
                string json = JsonSerializer.Serialize(req);
                byte[] rawData = Encoding.UTF8.GetBytes(json);
                Socket.BeginSend(rawData, 0, rawData.Length, SocketFlags.None, new AsyncCallback(OnDataSent), null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void OnConnectionResult(IAsyncResult asyncResult)
        {
            try
            {
                Socket.EndConnect(asyncResult);
                Console.WriteLine("Client: Connected");

                // listen for possible incoming data after connection
                Socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None,
                    new AsyncCallback(OnDataReceived), Socket);

                ActionOnServerConnectionAccepted();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                if (ex is SocketException)
                {
                    MessageBox.Show("Cannot connect to this host", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnDataSent(IAsyncResult asyncResult)
        {
            try
            {
                Console.WriteLine("Client: data sent to server");
                Socket.EndSend(asyncResult);
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
                int receivedBytes = Socket.EndReceive(asyncResult);
                byte[] rawData = new byte[receivedBytes];
                Array.Copy(Buffer, rawData, receivedBytes);

                // check if client has been disconnected
                if (receivedBytes == 0)
                {
                    HandleDisconnectedServer();
                    return;
                }

                ServerResponse? res = GetDataFromBytes(rawData);
                if (res != null)
                {
                    ActionOnDataReceived(res);
                }

                // continue listen for future messages
                Socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), Socket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private ServerResponse? GetDataFromBytes(byte[] bytes)
        {
            if (bytes.Length > 0)
            {
                string rawData = Encoding.UTF8.GetString(bytes);
                ServerResponse res = JsonSerializer.Deserialize<ServerResponse>(rawData)!;

                Console.WriteLine("Client: Data received " + rawData);

                return res;
            }

            return null;
        }

        private void HandleDisconnectedServer()
        {
            Console.WriteLine("Client: Server disconnected");
            Socket.Close();
        }

        public void SearchAvailableHosts()
        {
            NetworkDiscovery discoveryService = new NetworkDiscovery(localNetworkAddress, ActionOnDeviceDiscovered, ActionOnDiscoverFinished);
            discoveryService.DiscoverLocalNetworkHosts(Server.KNOWN_PORT);
        }
    }
}

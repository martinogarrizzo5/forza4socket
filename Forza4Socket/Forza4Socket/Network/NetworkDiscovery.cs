using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Forza4Socket.ServerSide;

namespace Forza4Socket.Network
{
    internal class NetworkDiscovery
    {
        Action<IPAddress> ActionOnNewHostAvailable;
        Action<List<IPAddress>> ActionOnDiscoveryFinished;

        System.Timers.Timer timer = new System.Timers.Timer(4000);
        List<SocketAsyncEventArgs> list = new List<SocketAsyncEventArgs>();

        public NetworkDiscovery(Action<IPAddress> onNewHostAvailable, Action<List<IPAddress>> OnDiscoveryFinished)
        {
            ActionOnNewHostAvailable = onNewHostAvailable;
            ActionOnDiscoveryFinished = OnDiscoveryFinished;
            timer.Elapsed += OnTimerExpiration;
        }

        public void DiscoverLocalNetworkHosts(int port)
        {
            timer.Start();
            Parallel.For(1, 255, (i, loopState) =>
            {
                ConnectTo("192.168.1." + i, port);
            });
        }

        private void ConnectTo(string ipAdd, int port)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            SocketAsyncEventArgs e = new SocketAsyncEventArgs();
            e.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(ipAdd), port);
            e.UserToken = s; // keep reference to the socket
            e.Completed += new EventHandler<SocketAsyncEventArgs>(OnHostConnected);
            list.Add(e); // Add to a list so we dispose all the sockets when the timer ticks.

            try
            {
                s.ConnectAsync(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void OnHostConnected(object sender, SocketAsyncEventArgs e)
        {
            if (e.ConnectSocket != null)
            {
                IPAddress ipAddress = ((IPEndPoint)e.RemoteEndPoint!).Address;
                ActionOnNewHostAvailable(ipAddress);
            }
        }

        private void OnTimerExpiration(object sender, EventArgs e)
        {
            List<IPAddress> discoveredHosts = new List<IPAddress>();

            timer.Stop();
            foreach (var s in list)
            {
                //disposing all sockets that's pending or connected using the reference to the socket saved in UserToken
                Socket socket = (Socket)s.UserToken!;
                IPAddress ipAddress = ((IPEndPoint)s.RemoteEndPoint!).Address;
                if (socket.Connected) discoveredHosts.Add(ipAddress);

                socket.Close();
                socket.Dispose();
            }

            ActionOnDiscoveryFinished(discoveredHosts);
        }
    }
}

using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Forza4Socket.Network
{
    internal class NetworkUtilities
    {
        // Hp: the ip address is a /24 address
        public static List<IPAddress> GetNetworkDevicesIPs()
        {
            List<IPAddress> IPs = new List<IPAddress>();
            List<UnicastIPAddressInformation> myAddresses = GetOwnedIPAddresses();

            foreach (var ip in myAddresses)
            {
                IPs.Add(ip.Address);
            }

            return IPs;
        }

        public static List<UnicastIPAddressInformation> GetOwnedIPAddresses()
        {
            List<UnicastIPAddressInformation> ipAddresses = new List<UnicastIPAddressInformation>();
            var nics = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var nic in nics)
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    {
                        var ipProps = nic.GetIPProperties();

                        foreach (var addr in ipProps.UnicastAddresses)
                        {
                            if (addr.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ipAddresses.Add(addr);
                                // TODO: DO SOMETHING WITH THE ADDRESS
                            }
                        }
                    }
                }
            }

            return ipAddresses;
        }

        public static async Task<bool> CheckDeviceServiceAvailable(string ip, int port)
        {
            bool isServiceAvailable = true;

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await socket.ConnectAsync(ip, port);

            if (!socket.Connected)
            {
                isServiceAvailable = false;
            }
            socket.Close();

            return isServiceAvailable;
        }
    }
}

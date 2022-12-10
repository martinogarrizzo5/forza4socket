using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Forza4Socket.ServerSide
{
    internal class ConnectedSocket
    {
        public Socket Socket { get; set; }
        public Player? Player { get; set; }

        public ConnectedSocket(Socket socket)
        {
            Socket = socket;
        }
    }
}

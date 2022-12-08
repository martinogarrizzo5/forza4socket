using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forza4Socket.ServerSide
{

    enum GameMode
    {
        Player,
        Spectator
    }

    internal class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public GameMode GameMode { get; set; }
    }
}

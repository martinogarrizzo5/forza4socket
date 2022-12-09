using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forza4Socket.Game;

namespace Forza4Socket.ServerSide
{
    [Serializable]
    internal class ServerResponse
    {
        public List<List<int>>? Grid { get; init; }
        public bool? IsCellSelectedInvalid { get; init; }
        public Cell? LastSelectedCell { get; init; }
        public bool? IsGameOver { get; init; }
        public int? WinningPlayerId { get; init; }
        public int? TurnPlayerId { get; init; }
        public List<Player>? Players { get; init; }
        public bool? GameStarted { get; init; }

        // player related to the socket
        public Player? Player { get; init; }


    }
}

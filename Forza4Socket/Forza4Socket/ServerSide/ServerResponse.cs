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
        public Grid? UpdatedGrid { get; init; }
        public bool? IsCellSelectedInvalid { get; init; }
        public Cell? SelectedCell { get; init; }
        public bool? IsGameOver { get; init; }
        public int? WinningPlayer { get; init; }
        public int? TurnPlayer { get; init; }
        public List<Player>? Players { get; init; }
        public bool? GameStarted { get; init; }

        // player related to the socket
        public Player? Player { get; init; }


    }
}

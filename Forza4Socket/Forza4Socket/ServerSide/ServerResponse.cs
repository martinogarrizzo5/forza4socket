using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forza4Socket.Grid;

namespace Forza4Socket.ServerSide
{
    internal class ServerResponse
    {
        public bool IsCellSelectable { get; init; }
        public Cell SelectedCell { get; init; }

        public int WinningPlayer { get; init; }
        public int TurnPlayer { get; init; }

        public Grid.Grid UpdatedGrid { get; init; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forza4Socket.Grid;

namespace Forza4Socket.Server
{
    internal class ServerResponse
    {
        public bool IsCellSelectable { get; private set; }
        public Cell SelectedCell { get; private set; }

        public int WinningPlayer { get; private set; }
        public int TurnPlayer { get; private set; }

        public Grid.Grid UpdatedGrid { get; private set; }
    }
}

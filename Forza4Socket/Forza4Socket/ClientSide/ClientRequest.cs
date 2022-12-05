using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forza4Socket.Game;

namespace Forza4Socket.ClientSide
{
    internal class ClientRequest
    {
        public string? Username { get; init; }
        public Cell? SelectedCell { get; init; }
        public bool? IsDisconnecting { get; init; }

        // TODO: only clients that specify in the request that they want to play can be seen as players by the server
        public bool CanPlayGame { get; init; }
    }
}

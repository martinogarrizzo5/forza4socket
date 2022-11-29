using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forza4Socket.Grid;

namespace Forza4Socket.ClientSide
{
    internal class ClientRequest
    {
        public string? Username { get; init; }
        public Cell? SelectedCell { get; init; }
        public bool? IsDisconnecting { get; init; }
    }
}

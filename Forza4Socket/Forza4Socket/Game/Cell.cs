using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forza4Socket.Game
{
    internal class Cell
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public int GetRow()
        {
            return Row;
        }
        public int GetColumn()
        {
            return Column;
        }
    }
}

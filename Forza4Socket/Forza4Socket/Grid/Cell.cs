using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forza4Socket.Grid
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

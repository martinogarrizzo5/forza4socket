using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forza4Socket.Grid
{
    internal class Grid
    {
        Cell c = new Cell();
        int[,] griglia = new int[6,7];
        public Grid()
        {
            for(int i = 0; i<6;i++)
            {
                for(int j = 0; j<7;j++)
                {
                    griglia[i,j] = 0;
                }
            }
        }
        public bool RowsControl(int p, int row)
        {
            for(int i = 0; i<6;i++)
            {
                int partenza = 0;
                int fine = 0;
                for (int j = 0; j < 7; j++)
                {
                    if (griglia[row, i] == p)
                    {
                        fine++;
                    }
                    else
                    {
                        partenza = i + 1;
                        fine = partenza;
                    }
                    if (fine - partenza == 4)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool ColumnsControl(int p, int column)
        {
            for (int i = 0; i < 7; i++)
            {
                int partenza = 0;
                int fine = 0;
                for (int j = 0; j < 6; j++)
                {
                    if (griglia[i,column] == p)
                    {
                        fine++;
                    }
                    else
                    {
                        partenza = i + 1;
                        fine = partenza;
                    }
                    if (fine - partenza == 4)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool DiagonalControl(int p)
        {
            int partenza = 0;
            int fine = 0;
            int i = 0;
            for (int k = 0; k < 7; k++)
            {
                for (int j = k; j < 6; j++)
                {
                    if (griglia[i, j] == p)
                    {
                        fine++;
                    }
                    else
                    {
                        partenza = j + 1;
                        fine = partenza;
                    }
                    i++;

                    if (fine - partenza == 4)
                    {
                        return true;
                    }
                }
              
            }
            return false;
        }
        public void InsertPawn(int row, int column)
        {
            int i = row;
            int j = column;
            bool isPositionFound = false;
            int position = -1;
            while (j < griglia.Length && !isPositionFound)
            {
               if(griglia[i, j] != 0)
               {
                    isPositionFound = true;
                    position = j - 1;
               }
               j++;
            }
        }
    }
}

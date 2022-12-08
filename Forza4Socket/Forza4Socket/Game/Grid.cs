using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forza4Socket.Game
{
    internal class Grid
    {
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public int RequiredPawns { get; private set; }
        public int[,] GameGrid { get; private set; }

        public Grid()
        {
            Columns = 7;
            Rows = 6;
            RequiredPawns = 4;

            GameGrid = new int[Rows, Columns];
            // insert default value 0
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    GameGrid[i, j] = -1;
                }
            }
        }

        public bool CheckRows(int pawn)
        {
            for (int i = 0; i < Rows; i++)
            {
                int start = 0;
                int end = 0;
                for (int j = 0; j < Columns; j++)
                {
                    if (GameGrid[i, j] == pawn)
                    {
                        end++;
                    }
                    else
                    {
                        start = j + 1;
                        end = start;
                    }
                    if (end - start == RequiredPawns)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckColumns(int pawn)
        {
            for (int i = 0; i < Columns; i++)
            {
                int start = 0;
                int end = 0;
                for (int j = 0; j < Rows; j++)
                {
                    if (GameGrid[j, i] == pawn)
                    {
                        end++;
                    }
                    else
                    {
                        start = j + 1;
                        end = start;
                    }
                    if (end - start == RequiredPawns)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckDiagonals(int p)
        {
            for (int k = 0; k < Columns; k++)
            {
                int start = 0;
                int end = 0;
                int i = 0;
                int j = k;

                while (i < Rows && j < Columns)
                {
                    if (GameGrid[i, j] == p)
                    {
                        end++;
                    }
                    else
                    {
                        start = j + 1;
                        end = start;
                    }

                    if (end - start == RequiredPawns)
                    {
                        return true;
                    }

                    i++;
                    j++;
                }
            }

            return false;
        }

        public void InsertPawn(int pawn, int row, int column)
        {
            int i = row;
            bool isPositionFound = false;
            int position = -1;

            while (i < Rows && !isPositionFound)
            {
                if (GameGrid[i, column] == -1)
                {
                    isPositionFound = true;
                }
                else
                {
                    position = i;
                }
            }

            GameGrid[position, column] = pawn;
        }
    }
}

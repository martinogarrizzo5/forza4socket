using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forza4Socket.Game
{
    [Serializable]
    internal class Forza4
    {
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public int RequiredPawns { get; private set; }
        public List<List<int>> GameGrid { get; private set; }

        public Forza4()
        {
            Columns = 7;
            Rows = 6;
            RequiredPawns = 4;
            GameGrid = new List<List<int>>();

            // insert default value 0
            for (int i = 0; i < Rows; i++)
            {
                GameGrid.Add(new List<int>());
                for (int j = 0; j < Columns; j++)
                {
                    GameGrid[i].Add(-1);
                }
            }

        }

        public bool CheckVictory(int pawn)
        {
            bool anyColumnValid = CheckColumns(pawn);
            bool anyRowValid = CheckRows(pawn);
            bool anyDiagonalValid = CheckAllDiagonals(pawn);

            return anyColumnValid || anyRowValid || anyDiagonalValid;
        }

        public bool CheckRows(int pawn)
        {
            for (int i = 0; i < Rows; i++)
            {
                int start = 0;
                int end = 0;
                for (int j = 0; j < Columns; j++)
                {
                    if (GameGrid[i][j] == pawn)
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
                    if (GameGrid[j][i] == pawn)
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

        public bool CheckAllDiagonals(int p)
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    if (CheckDiagonals(x, y, p))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckDiagonals(int x, int y, int player)
        {
            int diagonalSum = 0;

            for (int i = -2; i <= 2; i++)
            {
                // Check if the cell is within the bounds of the board
                if (x + i >= 0 && x + i < Columns && y + i >= 0 && y + i < Rows)
                {
                    // Add the value of the cell to the diagonal sum if it contains the given pawn
                    if (GameGrid[y + i][x + i] == player)
                    {
                        diagonalSum += player;
                    }
                }
            }

            return diagonalSum == RequiredPawns * player;
        }


        public bool InsertPawn(int pawn, int row, int column)
        {
            int i = row;
            bool isPositionFound = false;
            int position = -1;

            while (i < Rows && !isPositionFound)
            {
                if (GameGrid[i][column] != -1)
                {
                    isPositionFound = true;
                }
                else
                {
                    position = i;
                }

                i++;
            }

            if (position != -1)
            {
                GameGrid[position][column] = pawn;
                return true;
            }

            return false;
        }

        public void ClearGrid()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    GameGrid[i][j] = -1;
                }
            }
        }
    }
}

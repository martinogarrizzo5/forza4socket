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
            // right diagonals
            for (int n = 0; n < 3; n++)
            {
                for (int a = 0; a + 3 < 7; a++)
                {
                    if (GameGrid[n][a + 3] == p && GameGrid[n + 1][a + 2] == p && GameGrid[n + 2][a + 1] == p && GameGrid[n + 3][a] == p)
                    {
                        return true;
                    }
                }
            }

            // left diagonals
            for (int n = 0; n < 3; n++)
            {
                for (int a = 3; a > 0; a--)
                {
                    if (GameGrid[n][a + 3] == p && GameGrid[n + 1][a + 2] == p && GameGrid[n + 2][a + 1] == p && GameGrid[n + 3][a] == p)
                    {
                        return true;
                    }
                }
            }

            return false;
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

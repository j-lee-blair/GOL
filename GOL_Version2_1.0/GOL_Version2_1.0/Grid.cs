using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version2_1._0
{
    class Grid
    {
        private int max;
        private Cell[,] inputCells;
        private int neighbours;

        public Cell[,] Input { get { return this.inputCells; } }
        public int Neighbours { get { return this.neighbours; } set { this.neighbours = value; } }

        public Grid(int max)
        {
            this.max = max;
            this.inputCells = new Cell[max, max];
            InitGrid();
        }

        private void InitGrid()
        {
            for (int i = 0; i < inputCells.GetLength(0); i++)
            {
                for (int j = 0; j < inputCells.GetLength(0); j++)
                {
                    inputCells[i,j] = new Cell(i, j);
                    inputCells[i, j].Alive = false;
                }
            }
        }

        public void AddCell(int x, int y)
        {
            this.inputCells[x, y].Alive = true;
        }

        public void Tick()
        {
            Cell[,] outputCells = new Cell[max,max];
            Rules r = new Rules();
            bool result = false;

            for (int i = 0; i < inputCells.GetLength(0); i++)
            {
                for (int j = 0; j < inputCells.GetLength(0); j++)
                {
                    while (!result)
                    {
                        result = (this.neighbours = GetNeighbours(i, j)) < 2 ? r.LessThanTwoNeighbours(inputCells[i, j]) : false;
                        result = (this.neighbours = GetNeighbours(i, j)) == 3 ? r.ThreeNeighboursExactly(inputCells[i, j]) : false;
                    }
                }
            }
        }

        public int GetNeighbours(int row, int col)
        {
            //number of neighbours
            int count = 0;

            //if neighbouring cell is within bounds and alive increment count
            count += row - 1 >= 0 && col - 1 >= 0 && inputCells[row - 1, col - 1].Alive ? 1 : 0;
            count += row - 1 >= 0 && inputCells[row - 1, col].Alive ? 1 : 0;
            count += row - 1 >= 0 && col + 1 < max && inputCells[row - 1, col + 1].Alive ? 1 : 0;
            count += row + 1 < max && col - 1 >= 0 && inputCells[row + 1, col - 1].Alive ? 1 : 0;
            count += row + 1 < max && inputCells[row + 1, col].Alive ? 1 : 0;
            count += row + 1 < max && col + 1 < max && inputCells[row + 1, col + 1].Alive ? 1 : 0;
            count += col - 1 >= 0 && inputCells[row, col - 1].Alive ? 1 : 0;
            count += col + 1 < max && inputCells[row, col + 1].Alive ? 1 : 0;

            return count;
        }
    }
}

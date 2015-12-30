using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version1_1._0
{
    class Grid
    {
        private int max;
        private Cell[,] inputCells;
        
        public Cell[,] Input { get { return inputCells; } }

        public Grid(int max)
        {
            this.max = max;
            inputCells = new Cell[max, max];
        }

        public Cell AddLiveCell(int x, int y)
        {
            inputCells[x, y].Alive = true;
            GetNeighbouringCells();
            return inputCells[x,y];
        }

        //Starting values for World
        public void InitGrid()
        {
            for (int i = 0; i < inputCells.GetLength(0); i++)
            {
                for (int j = 0; j < inputCells.GetLength(0); j++)
                {
                    inputCells[i, j] = new Cell(i, j);
                }
            }
        }

        //if neighbours are to be calculated from the PopulateWorld method, 
        public void GetNeighbouringCells()
        {
            for (int i = 0; i < inputCells.GetLength(0); i++)
            {
                for (int j = 0; j < inputCells.GetLength(0); j++)
                {
                    inputCells[i, j].Neighbours = GetNeighbouringCells(i, j);
                }
            }
        }

        private int GetNeighbouringCells(int row, int col)
        {
            //number of neighbours
            int count = 0; 

            //if neighbouring cell is within bounds and alive increment count
            count += row-1 >= 0 && col-1 >=0 && inputCells[row-1,col-1].Alive ? 1 : 0;
            count += row-1 >= 0 && inputCells[row-1, col].Alive ? 1 : 0;
            count += row-1 >= 0 && col+1 < max && inputCells[row-1, col+1].Alive ? 1 : 0;
            count += row+1 < max && col-1 >= 0 && inputCells[row+1, col-1].Alive ? 1 : 0;
            count += row+1 < max && inputCells[row+1, col].Alive ? 1 : 0;
            count += row+1 < max && col+1< max && inputCells[row+1, col+1].Alive ? 1 : 0;
            count += col-1 >= 0 && inputCells[row, col-1].Alive ? 1 : 0;
            count += col+1 < max && inputCells[row, col+1].Alive ? 1 : 0;

            return count;
        }

        private void GrowGrid(int max)
        {
            
        }

        private int NewSize(int size)
        {
            int newSize = Math.Max(1, (int)Math.Ceiling(0.2 * size));
            return newSize;
        }

        public void Tick()
        {
            Rules r = new Rules();
            Cell[,]outputCells = new Cell[max, max];

            for (int i = 0; i < inputCells.GetLength(0); i++)
            {
                for (int j = 0; j < inputCells.GetLength(0); j++)
                {
                    r.CheckRules(inputCells[i,j]);
                    outputCells[i, j] = inputCells[i, j];
                }
            }

            //transfer post-tick output values to new input ready for next tick 
            inputCells = outputCells;
            GetNeighbouringCells();
        }
    }
}

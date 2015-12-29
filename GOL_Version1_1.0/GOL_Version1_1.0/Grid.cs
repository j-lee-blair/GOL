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
        private Cell[,] outputCells;

        public Cell[,] Output {get { return outputCells; }}
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
        public void InitWorld()
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
                    
                    //for debug purposes only
                    //Console.WriteLine(inputCells[i, j].ToString());
                }
            }
        }

        private int GetNeighbouringCells(int row, int col)
        {
            //number of neighbours
            int count = 0; 

            //calculate x,y for each neighbouring group
            int up = row - 1;
            int left = col - 1;

            int down = row + 1;
            int right = col + 1;

            //if neighbouring cell is alive count++ else no effect
            count += up >= 0 && left >=0 && inputCells[up,left].Alive ? 1 : 0;
            count += up >= 0 && inputCells[up, col].Alive ? 1 : 0;
            count += up >= 0 && right < max && inputCells[up, right].Alive ? 1 : 0;

            count += down < max && left >= 0 && inputCells[down, left].Alive ? 1 : 0;
            count += down < max && inputCells[down, col].Alive ? 1 : 0;
            count += down < max && right < max && inputCells[down, right].Alive ? 1 : 0;

            count += left >= 0 && inputCells[row, left].Alive ? 1 : 0;
            count += right < max && inputCells[row, right].Alive ? 1 : 0;

            return count;
        }

        public void Tick()
        {
            Rules r = new Rules();
            outputCells = new Cell[max, max];

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

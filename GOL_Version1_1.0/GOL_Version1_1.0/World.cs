using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version1_1._0
{
    class World
    {
        private Cell[,] inputCells;
        private Cell[,] outputCells;
        private int max;

        public Cell[,] Output {get { return outputCells; }}
        public Cell[,] Input { get { return inputCells; } }

        public World(int max)
        {
            this.max = max;
            inputCells = new Cell[max, max];
        }

        public Cell AddLiveCell(int x, int y)
        {
            inputCells[x, y].Alive = true;
            return inputCells[x,y];
        }

        public void PopulateWorld()
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
                    
                    //debug
                    Console.WriteLine(inputCells[i, j].ToString());
                }
            }
        }

        private int GetNeighbouringCells(int row, int col)
        {
            int count = 0;
            int up = (row - 1) < 0 ? 0 : row - 1;
            int down = (row + 1) == max ? 0 : row + 1;
            int left = (col - 1) < 0 ? 0 : col - 1;
            int right = (col + 1) == max ? 0 : col + 1;

            count += inputCells[up,left].Alive ? 1 : 0;
            count += inputCells[up, col].Alive ? 1 : 0;
            count += inputCells[up, right].Alive ? 1 : 0;

            count += inputCells[down, left].Alive ? 1 : 0;
            count += inputCells[down, col].Alive ? 1 : 0;
            count += inputCells[down, right].Alive ? 1 : 0;

            count += inputCells[row, left].Alive ? 1 : 0;
            count += inputCells[row, right].Alive ? 1 : 0;

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
                }
            }

            inputCells = outputCells;
        }

      

    }
}

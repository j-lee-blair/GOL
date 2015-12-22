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
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    inputCells[i, j] = new Cell(i, j);
                    GetNeighbouringCells(i, j);
                }
            }
        }

        private void GetNeighbouringCells()
        {
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    inputCells[i, j].Neighbours = GetNeighbouringCells(i, j);
                }
            }
        }

        private int GetNeighbouringCells(int row, int col)
        {
            int count = 0;

            int rowStart = Math.Max(row - 1, 0);
            int rowFinish = Math.Min(row + 1, inputCells.Length - 1);
            int colStart = Math.Max(col - 1, 0);
            int colFinish = Math.Min(col + 1, inputCells.Length - 1);

            for (int curRow = rowStart; curRow <= rowFinish; curRow++)
            {
                for (int curCol = colStart; curCol <= colFinish; curCol++)
                {
                    count++;
                }
            }

            //if (Math.Min(0, row-1) > -1 && Math.Min(0, col-1) > -1)
            //{

            //    if (inputCells[row - 1, col - 1] != null)
            //    {
            //        count++;
            //    }
            //    if (inputCells[row, col - 1] != null)
            //    {
            //        count++;
            //    }
            //    if (inputCells[row + 1, col - 1] != null)
            //    {
            //        count++;
            //    }
            //    if (inputCells[row - 1, col] != null)
            //    {
            //        count++;
            //    }
            //    if (inputCells[row + 1, col] != null)
            //    {
            //        count++;
            //    }
            //    if (inputCells[row - 1, col + 1] != null)
            //    {
            //        count++;
            //    }
            //    if (inputCells[row, col + 1] != null)
            //    {
            //        count++;
            //    }
            //    if (inputCells[row + 1, col + 1] != null)
            //    {
            //        count++;
            //    }
            //}
            return count;
        }

        public void Tick()
        {
            Rules r = new Rules();
            outputCells = new Cell[max, max];

            for (int i = 0; i < inputCells.Length; i++)
            {
                for (int j = 0; j < inputCells.Length; j++)
                {
                    r.CheckRules(inputCells[i,j]);        
                }
            }

            inputCells = outputCells;
        }

            //BETTER NEIGHBOUR METHOD
            //        row_limit = count(array);
            //if(row_limit > 0){
            //  column_limit = count(array[0]);
            //  for(x = max(0, i-1); x <= min(i+1, row_limit); x++){
            //    for(y = max(0, j-1); y <= min(j+1, column_limit); y++){
            //      if(x != i || y != j){
            //        print array[x][y];
            //      }
            //    }
            //  }
            //}

    }
}

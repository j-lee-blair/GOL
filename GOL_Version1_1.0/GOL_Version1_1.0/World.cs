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
                }
            }
        }

        private void Loop()
        {
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    inputCells[i, j].Neighbours = GetNeighbouringCells(i, j);
                }
            }
        }

        private int GetNeighbouringCells(int x, int y)
        {
            int count = 0;

            if (inputCells[x - 1, y - 1] != null)
            {
                count++;
            }
            if (inputCells[x, y - 1] != null)
            {
                count++;
            }
            if (inputCells[x + 1, y - 1] != null)
            {
                count++;
            }
            if (inputCells[x - 1, y] != null)
            {
                count++;
            }
            if (inputCells[x + 1, y] != null)
            {
                count++;
            }
            if (inputCells[x - 1, y + 1] != null)
            {
                count++;
            }
            if (inputCells[x, y + 1] != null)
            {
                count++;
            }
            if (inputCells[x + 1, y + 1] != null)
            {
                count++;
            }
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
    }
}

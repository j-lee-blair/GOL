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
        private int livingCells;

        public int LivingCells{get { return livingCells; } }
        
        public World(int max)
        {
            this.max = max;
            inputCells = new Cell[max, max];
            livingCells = 0;
        }

        public Cell AddCell(int x, int y)
        {
            Cell cell = new Cell(true);
            inputCells[x, y] = cell;
            cell.SetPosition(x, y);
            livingCells++;
            return cell;
        }

        public void PopulateWorld()
        {
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    inputCells[i, j] = new Cell();
                }
            }
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

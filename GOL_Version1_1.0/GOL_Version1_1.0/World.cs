using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version1_1._0
{
    class World
    {
        private Cell[,] cells;
        private int max;


        public World()
        {
            cells = new Cell[max, max];
        }

        public Cell AddCell(int x, int y)
        {
            Cell cell = new Cell();
            cells[x, y] = cell;
            cell.SetPosition(x, y);
            return cell;
        }

        public void Tick()
        {
 
        }
    }
}

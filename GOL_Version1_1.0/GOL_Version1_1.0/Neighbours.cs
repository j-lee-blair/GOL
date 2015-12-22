using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version1_1._0
{
    class Neighbours
    {
        List<Cell> neighbours;

        public int numNeighbours() { return neighbours.Count; }

        public Neighbours()
        {

        }


        public Neighbours(Cell currentCell)
        {
            //CalculateNeighbours(currentCell);
        }

        private List<Cell> CalculateNeighbours(Cell current)
        {
            int neighbours = 0;

            if (current[x - 1, y - 1])
            {
                neighbours++;
            }
            if (Cell[x, y - 1])
            {
                neighbours++;
            }
            if (Cell[x + 1, y - 1])
            {
                neighbours++;
            }
            if (Cell[x - 1, y])
            {
                neighbours++;
            }
            if (Cell[x + 1, y])
            {
                neighbours++;
            }
            if (Cell[x - 1, y + 1])
            {
                neighbours++;
            }
            if (Cell[x, y + 1])
            {
                neighbours++;
            }
            if (Cell[x + 1, y + 1])
            {
                neighbours++;
            }

            return neighbours;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version1_1._0
{
    class Neighbours
    {
        List<Cell> neighbours;

        public int numNeighbours() { return neighbours.Count; }

        public Neighbours(Cell currentCell)
        {
            CalculateNeighbours(currentCell);
        }

        private List<Cell> CalculateNeighbours(Cell current)
        {
            //code for calculating neighbours
            return neighbours;
        }
        
    }
}

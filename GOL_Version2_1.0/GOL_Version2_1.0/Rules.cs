using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version2_1._0
{
    class Rules
    {
        public bool LessThanTwoNeighbours(Cell c)
        {
            c.Alive = false;
            return true;
        }

        public bool ThreeNeighboursExactly(Cell cell)
        {
            cell.Alive = true;
            return true;
        }
    }
}

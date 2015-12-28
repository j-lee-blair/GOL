using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version1_1._0
{
    class Rules
    {

        public void CheckRules(Cell current)
        {
            //If a cell has less than 2 neighbours, cell dies
            if (current.Neighbours < 2)
            {
                current.Alive = false;
            }

            //If a cell has more than three neighbours, cell dies
            else if (current.Neighbours > 3)
            {
                current.Alive = false;
            }

            //If a cell has 2-3 live neighbours, cell survives
            //if (current.Alive == true && current.Neighbours == 2)
            //{
            //    return;
            //}

            //*********************DEAD CELLS ONLY ***************
            //If a dead cell has exactly 3 neighbours, cell is populated
            else if (current.Alive == false && current.Neighbours == 3)
            {
                current.Alive = true;
            }
        }
    }
}

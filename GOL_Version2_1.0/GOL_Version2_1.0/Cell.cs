using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version2_1._0
{
    class Cell
    {
        private int x;
        private int y;
        private bool alive;

        public bool Alive { get { return this.alive; } set { this.alive = value; } }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.Alive = false;
        }
    }
}

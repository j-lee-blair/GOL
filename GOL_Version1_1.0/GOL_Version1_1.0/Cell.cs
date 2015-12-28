using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version1_1._0
{
    class Cell
    {
        private bool alive;
        private int x;
        private int y;
        private int neighbours;

        public bool Alive { get { return alive; } set { alive = value; } }
        public int Neighbours { get { return this.neighbours; } set { neighbours = value; } }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.alive = false;
        }

        public Cell(bool alive)
        {
            this.alive = false;
        }

        public void SwitchState(bool state)
        {
            alive = state;
        }

        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}", "Neighbour Count Cell[", x + ", ", y + "] :\t", Neighbours.ToString());
        }
    }
}

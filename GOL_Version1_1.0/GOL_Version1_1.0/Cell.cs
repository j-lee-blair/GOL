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
        private Neighbours neighbours;

        public bool Alive { get { return alive; } set { alive = value; } }
        public int Neighbours { get { return this.neighbours.Neighbours(); } }

        public Cell()
        {
            this.neighbours = new Neighbours(this);
            this.alive = false;
        }

        public Cell(bool alive)
        {
            this.neighbours = new Neighbours(this);
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
    }
}

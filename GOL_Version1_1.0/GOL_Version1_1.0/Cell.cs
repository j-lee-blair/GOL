using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version1_1._0
{
    class Cell
    {
        private bool alive;
        private int liveNeighbours;
        private int x;
        private int y;

        public bool Alive{get { return alive; }set { alive = value; }}
        public int NumOfNeighbours{get { return liveNeighbours; }set { liveNeighbours = value; }}
        

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

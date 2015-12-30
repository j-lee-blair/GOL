using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GOL_Version1_1._0
{
    
    class TestWorld 
    {

        [Test]
        public void OneCellIsAddedToWorld()
        {
            Grid w = new Grid(5);
            w.InitGrid();
            w.AddLiveCell(1, 1);
            Assert.True(w.Input[1,1].Alive == true);
        }

        [Test]
        public void CellHasLessThanTwoNeighbours()
        {
            Grid w = new Grid(3);
            w.InitGrid();
            w.AddLiveCell(1,1);
            w.Tick();
            Assert.True(w.Input[1, 1].Alive == false);
        }
    }
}

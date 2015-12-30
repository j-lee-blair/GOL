using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GOL_Version2_1._0
{
    class Test
    {
        [Test]
        public void OneCellIsAddedToWorld()
        {
            Grid g = new Grid(3);
            g.AddCell(2, 2);
            Assert.True(g.Input[2, 2].Alive == true);
        }

        [Test]
        public void CellHasNoNeighbours()
        {
            Grid g = new Grid(3);
            g.AddCell(2,2);
            Assert.True(g.GetNeighbours(2,2) == 0);
        }

        [Test]
        public void CellDiesIfLessThanTwoNeighbours()
        {
            Grid g = new Grid(3);
            g.AddCell(1,1);
            g.Tick();
            Assert.True(g.Input[2, 2].Alive == false);
        }

        [Test]
        public void CellLivesIfExactlyThreeNeighbours()
        {
            Grid g = new Grid(3);
            g.AddCell(0, 0);
            g.AddCell(0, 1);
            g.AddCell(0, 2);
            g.Tick();
            Assert.True(g.Input[1, 1].Alive == true);
        }
    }
}

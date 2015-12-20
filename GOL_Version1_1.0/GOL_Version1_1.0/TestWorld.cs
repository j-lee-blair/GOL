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
            World world = new World(5);
            Assert.True(world.LivingCells == 1);
        }

        [Test]
        public void CellHasLessThanTwoNeighbours()
        {
            World world = new World(3);
            Cell c = world.AddCell(1,1);
            world.Tick(c);
            Assert.True(c.Alive == false);
        }
    }
}

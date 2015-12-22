using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version1_1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            World w = new World(3);
            w.PopulateWorld();

            w.AddLiveCell(1, 1);

            w.Tick();


        }
    }
}

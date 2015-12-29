using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version1_1._0
{
    class Game
    {
        static void Main(string[] args)
        {
            Grid g = new Grid(3);
            View v = new View(g);
            g.InitWorld();

            g.AddLiveCell(0, 0);
            g.AddLiveCell(0, 1);
            g.AddLiveCell(0, 2);
            v.UpdateDisplay();            

            Console.ReadLine();
            g.Tick();
            v.UpdateDisplay();

            Console.ReadLine();
            //g.AddLiveCell(0, 2);
            v.UpdateDisplay();

            Console.ReadLine();
            g.Tick();
            v.UpdateDisplay();
            
            Console.ReadLine();
            g.Tick();
            v.UpdateDisplay();
     
            Console.ReadLine();
        }
    }
}

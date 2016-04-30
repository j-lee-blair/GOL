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
            Grid g = new Grid(10);
            View v = new View(g);
            g.InitGrid();

            g.AddLiveCell(0, 0);
            g.AddLiveCell(0, 1);
            g.AddLiveCell(0, 2);
            g.AddLiveCell(0, 3);
            g.AddLiveCell(0, 4);
            g.AddLiveCell(0, 5);
            g.AddLiveCell(0, 6);
            v.UpdateDisplay();            

            Start(g, v);
            
        }
        
        private static void Start(Grid g, View v)
        {
            while (true)
            {
                Console.ReadLine();
                g.Tick();
                v.UpdateDisplay();
                
            }
        }
    }
}

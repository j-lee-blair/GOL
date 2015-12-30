using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL_Version1_1._0
{
    class View
    {
        Grid grid;

        public View(Grid g)
        {
            this.grid = g;
        }

        public void UpdateDisplay()
        {
            Console.Clear();
            for (int i = 0; i < grid.Input.GetLength(0); i++)
            {
                for (int j = 0; j < grid.Input.GetLength(0); j++)
                {
                    Console.ForegroundColor = grid.Input[i, j].Alive ? ConsoleColor.Magenta : ConsoleColor.Blue;
                    Console.Write(grid.Input[i, j].ToString());
                }
                Console.WriteLine("");
            }
        }
    }
}

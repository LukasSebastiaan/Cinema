using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class LoginMenu
    {
        public int Run()
        {
            Console.Clear();
            ConsoleKeyInfo key;
            api.PrintCenter("Login", 10);
            do
            {
                key = Console.ReadKey(true);
            }
            while (key.Key != ConsoleKey.Escape);
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class TimeSelection
    {
        private void Firstrender()
        {
            var Movies = new MoviesList();
            Movies.Load();
        }

        public int Run()
        {
            Console.Clear();
            Firstrender();  
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

            }
            while (key.Key != ConsoleKey.Escape);

            return 0;

        }   
    }
}

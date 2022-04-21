using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class TimeSelection
    {
        public int Index;
        public List<Movies> M;
        public TimeSelection()
        {
            var Movies = new MoviesList();
            Movies.Load();
            M = Movies.Movies;

        }
        private void Firstrender()
        {
            api.PrintCenter("<<*Select the time on which you would like to see your movie*>>", 1);
            api.PrintCenter("ARROW UP/DOWN - Select time| ENTER - Comfirm time | ESCAPE - Exit", 28);
            
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

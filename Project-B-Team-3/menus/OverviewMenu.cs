using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ProjectB
{
    internal class OverviewMenu
    {
        private int Index;
        private List<api.Textbox> Textboxes = new List<api.Textbox>();
        private const int OFFSET = 0;

        private string _moviename = "Spiderman: Last one home";
        private string _date = "25 jun 2022";
        private string _time = "12:00";
        private int[][] seats = {
	    new int[] { 1, 2 },
	    new int[] { 1, 3 },
	    new int[] { 2, 2 }
	};

        private bool _popcorn = false;

        public OverviewMenu()
	{
            Index = 0;
        }

        public void FirstRender()
	{
            api.PrintCenter("Here is the overview. Do you want to continue?", 5);

            api.PrintCenter("Movie", 8, ConsoleColor.White, ConsoleColor.Black);
            api.PrintCenter($"{_moviename}", 9);

            api.PrintCenter("Date and time", 11, ConsoleColor.White, ConsoleColor.Black);
            api.PrintCenter($"{_date}", 12);
            api.PrintCenter($"{_time}", 13);

            api.PrintCenter("Seats", 15, ConsoleColor.White, ConsoleColor.Black);

            string footer = "ARROW KEYS / TAB - Change box  |  ENTER - Finish  |  ESCAPE - Go back";
	    Console.SetCursorPosition((Console.WindowWidth - footer.Length) / 2, 28);
            Console.WriteLine(footer);
        }


        public int Run()
        {
            Console.Clear();
            FirstRender();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                ConsoleKey keyPressed = key.Key;

                
		
                if (keyPressed == ConsoleKey.Tab || keyPressed == ConsoleKey.DownArrow)
                {
                    if (Index < Textboxes.Count-1)
                    {
                        Index++;
                    }
                    else
                    {
                        Index = 0;
                    }
                 }
		else if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (Index > 0)
                    {
                        Index--;
                    }
                }

                if (Index < Textboxes.Count)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        Textboxes[Index].Backspace();
                    }
                    else
                    {
                        Textboxes[Index].AddLetter(key.KeyChar);
                    }
                }
            }
            while (key.Key != ConsoleKey.Escape);
	    
            return 0;
        }
    }
}

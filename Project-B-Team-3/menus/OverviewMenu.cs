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
        private List<api.Button> Buttons;
        private const int OFFSET = 0;

        private string _moviename = "Spiderman: Last one home";
        private string _date = "25 jun 2022";
        private string _time = "12:00";
        private int[][] seats = {
	    new int[] { 1, 2 },
	    new int[] { 1, 3 },
	    new int[] { 2, 2 }
	};
        private Dictionary<int, List<int>> _seats = new Dictionary<int, List<int>>();

        private bool _popcorn = false;

        public OverviewMenu()
	{
            Index = 0;

            Buttons = api.Button.CreateRow(new string[] { "Go Back", "Get Popcorn", "Confirm" }, 3, 25);

            // Make seats into a dict that holds seats for every row
            foreach (int[] seat in seats)
	    {
		if (_seats.ContainsKey(seat[0]))
		{
                    _seats[seat[0]].Add(seat[1]);
                }
                else
                {
                    _seats.Add(seat[0], new List<int>());
                    _seats[seat[0]].Add(seat[1]);
                }
	    }
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

            int y = 16;
            foreach (var row in _seats.Keys)
	    {
		foreach (var seat in _seats[row])
		{
                    api.PrintCenter($"row {row}, seat {seat}", y);
                    y++;
                }
	    }

            DrawButtons();

            string footer = "ARROW KEYS - Change box  |  ENTER - Confirm  |  ESCAPE - Go back";
	    Console.SetCursorPosition((Console.WindowWidth - footer.Length) / 2, 28);
            Console.WriteLine(footer);
        }

	public void DrawButtons()
	{
	    foreach (var button in Buttons)
	    {
                button.Display(Index);
            }
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



                if (keyPressed == ConsoleKey.RightArrow)
                {
                    if (Index < Buttons.Count - 1)
                    {
                        Index++;
                    }
                    else
                    {
                        Index = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.LeftArrow)
                {
                    if (Index > 0)
                    {
                        Index--;
                    }
                }
                DrawButtons();
            }
            while (key.Key != ConsoleKey.Escape);
	    
            return 0;
        }
    }
}

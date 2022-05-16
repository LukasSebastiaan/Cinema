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
        private int[] Index = new int[] {1, 0};
        private List<api.Button> Buttons;
        private const int OFFSET = 0;

        private string _moviename = Program.information.ChosenFilm.Name;
        private string _date = Program.information.ChosenDate;
        private string _time = Program.information.ChosenTime;
        private int[][] seats = Program.information.ChosenSeats;
        private ReservationsHandler accounthandler = new ReservationsHandler();

        private Dictionary<int, List<int>> _seats = new Dictionary<int, List<int>>();
        private int _popcornAmount = 0;

        public OverviewMenu()
	{
            Buttons = api.Button.CreateRow(new string[] { "Go Back", "Confirm" }, 3, 25);

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
		    if (y < 19)
		    {
			api.PrintCenter($"row {row}, seat {seat}", y);			
		    }
		    else if (y == 19)
		    {
			api.PrintCenter($"...", y);
		    }
                    y++;
                }
	    }

	    api.PrintCenter("Popcorn", 20, ConsoleColor.White, ConsoleColor.Black);
	    

            DrawButtons();

            string footer = "ARROW KEYS - Change box  |  ENTER - Confirm  |  ESCAPE - Go back";
	    Console.SetCursorPosition((Console.WindowWidth - footer.Length) / 2, 28);
            Console.WriteLine(footer);
        }

	public void DrawButtons()
	{
	    foreach (var button in Buttons)
	    {
                if (Index[0] == 1)
                {
                    button.Display(Index[1]);
                }
		else
		{
                    button.Display(-1);
                }
            }

	    // Print Popcorn
            if (Index[0] == 1)
	    {
		api.PrintCenter($"{_popcornAmount}".PadLeft(3).PadRight(5), 21, background: ConsoleColor.DarkGray, foreground: ConsoleColor.Black);
	    }
	    if (Index[0] == 0)
	    {
		api.PrintCenter($"{_popcornAmount}".PadLeft(3).PadRight(5), 21, background: ConsoleColor.Gray, foreground: ConsoleColor.Black);
	    }

            api.PrintExact("<", Console.WindowWidth / 2 - 5, 21);
	    api.PrintExact(">", Console.WindowWidth / 2 + 3, 21);

            // calculate price: movieprice*amountofseats + popcornprice*amountofseats
            double total_price = 15.49 * seats.Length + (3.49 * _popcornAmount);
            api.PrintCenter($"    Total price: {total_price.ToString("#.##")}$    ", 23, foreground: ConsoleColor.Green);
        }

       
        public int Run()
        {
            Console.Clear();
            FirstRender();
            ConsoleKeyInfo key;

            do
            {
				var info = Program.information;
				key = Console.ReadKey(true);
                ConsoleKey keyPressed = key.Key;

		if (keyPressed == ConsoleKey.Enter)
		{
		    if (Index[1] == 0)
		    {
                        return -1;
                    }
		    if (Index[1] == 1)
		    {
                        accounthandler.Add(Program.information, _popcornAmount);
						info.PopcornAmount = _popcornAmount;
						Program.information = info;
						return 1;
                    }
		}
		if (keyPressed == ConsoleKey.UpArrow)
		{
		    if (Index[0] == 1)
		    {
			Index[0]--;
		    }
		}
		if (keyPressed == ConsoleKey.DownArrow)
		{
		    if (Index[0] == 0)
		    {
			Index[0]++;
		    }
		}
		    
                if (keyPressed == ConsoleKey.RightArrow)
                {
		    if (Index[0] == 0)
		    {
			if (_popcornAmount < 100)
			{
			    _popcornAmount++;
			}
		    }
		    else
		    {
			if (Index[1] < Buttons.Count - 1)
			{
			    Index[1]++;
			}
			else
			{
			    Index[1] = 0;
			}
		    }
                }
                else if (keyPressed == ConsoleKey.LeftArrow)
                {
		    if (Index[0] == 0)
		    {
			if (_popcornAmount > 0)
			{
			    _popcornAmount--;
			}
		    }
		    else
		    {			
			if (Index[1] > 0)
			{
			    Index[1]--;
			}
		    }
                }
                DrawButtons();
            }
            while (key.Key != ConsoleKey.Escape);
	    
            return 1;
        }
    }
}

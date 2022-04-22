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
    internal class SeatsMenu
    {
        private int[] Index;
        private string[][] TakenSeats;

        private const int ROWS = 5;
        private const int AMOUNT = 10;

        public SeatsMenu()
	{
            Index = new int[] { 0, 5 };


	    // In the future this should load from a json
            TakenSeats = new string[ROWS][];

            for (int rownumber = 0; rownumber < ROWS; rownumber++)
            {
                TakenSeats[rownumber] = new string[AMOUNT];
            }
            TakenSeats[1][5] = "taken";
            TakenSeats[2][5] = "taken";
	    TakenSeats[3][5] = "taken";
	    TakenSeats[4][5] = "taken";
            TakenSeats[1][6] = "taken";
	    TakenSeats[1][7] = "taken";
	    TakenSeats[1][8] = "taken";
	    TakenSeats[1][9] = "taken";
            TakenSeats[0][2] = "taken";
            TakenSeats[1][2] = "taken";
	    TakenSeats[1][1] = "taken";
	    TakenSeats[1][0] = "taken";
	    


        }

        private void FirstRender()
	{
            api.PrintCenter("  screen  ", 20, background: ConsoleColor.White, foreground: ConsoleColor.Black);

            DrawSeats();

            api.PrintCenter("Hold CTRL to move through boxes", 27);
            string footer = "ARROW KEYS - Change Position  |  ENTER - Select Chair  |  ESCAPE - Go back" ;
            Console.SetCursorPosition((Console.WindowWidth - footer.Length) / 2, 28);
            Console.WriteLine(footer);
        }

        private void DrawSeats()
        {
	    for (int x = 0; x < ROWS; x++)
            {
		Console.SetCursorPosition(Console.WindowWidth / 2 - "                                       ".Length / 2, 10+x*2);
                for (int i = 0; i < AMOUNT; i++)
                {
                    DrawSeat(TakenSeats[x][i], Index[0] == x && Index[1] == i);
                    Console.Write(' ');
                }
                Console.Write("\n\n");
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

		// This piece handles turning a free chair into a chosen chair when
		// the user pressed enter on it. Also makes the chair free if it was
		// chosen by the user before
                if (keyPressed == ConsoleKey.Enter)
                {
                    if (TakenSeats[Index[0]][Index[1]] == null)
                    {
                        if (TakenSeats[Index[0]][Index[1]] != "taken")
                        {
                            TakenSeats[Index[0]][Index[1]] = "chosen";
                        }
                    }
		    else if (TakenSeats[Index[0]][Index[1]] == "chosen")
                    {
                        TakenSeats[Index[0]][Index[1]] = null;
                    }
                }

		
                if (keyPressed == ConsoleKey.DownArrow)
                {
                    if (Index[0] < ROWS)
                    {
                        Index[0]++;
                        if (Index[0] >= ROWS)
			{
                            Index[0] = 0;
                        }
                        if (!key.Modifiers.HasFlag(ConsoleModifiers.Control))
                        {
                            while (TakenSeats[Index[0]][Index[1]] == "taken")
                            {
                                Index[0]++;
                                if (Index[0] >= ROWS)
                                {
                                    Index[0]--;
                                    while (TakenSeats[Index[0]][Index[1]] == "taken")
                                    {
                                        Index[0]--;
                                    }
                                }
                            }
                        }
                    }
                }
		
		else if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (Index[0] >= 0)
                    {
                        Index[0]--;
                        if (Index[0] < 0)
                        {
                            Index[0] = ROWS - 1;
                        }
                        if (!key.Modifiers.HasFlag(ConsoleModifiers.Control))
                        {
                            while (TakenSeats[Index[0]][Index[1]] == "taken")
                            {
                                Index[0]--;
                                if (Index[0] < 0)
                                {
                                    Index[0]++;
                                    while (TakenSeats[Index[0]][Index[1]] == "taken")
                                    {
                                        Index[0]++;
                                    }
                                }
                            }
                        }
                    }
                }
		
		else if (keyPressed == ConsoleKey.RightArrow)
                {
                    if (Index[1] < AMOUNT)
                    {
                        Index[1]++;
                        if (Index[1] >= AMOUNT)
                        {
                            Index[1] = 0;
                        }
                        if (!key.Modifiers.HasFlag(ConsoleModifiers.Control))
                        {
                            while (TakenSeats[Index[0]][Index[1]] == "taken")
                            {
                                Index[1]++;
                                if (Index[1] >= AMOUNT - 1)
                                {
                                    Index[1]--;
                                    while (TakenSeats[Index[0]][Index[1]] == "taken")
                                    {
                                        Index[1]--;
                                    }
                                }
                            }
                        }
                    }
                }
		else if (keyPressed == ConsoleKey.LeftArrow)
                {
                    if (Index[1] >= 0)
                    {
                        Index[1]--;
                        if (Index[1] < 0)
                        {
                            Index[1] = AMOUNT - 1;
                        }
                        if (!key.Modifiers.HasFlag(ConsoleModifiers.Control))
                        {
                            while (TakenSeats[Index[0]][Index[1]] == "taken")
                            {
                                Index[1]--;
                                if (Index[1] < 0)
                                {
                                    Index[1]++;
                                    while (TakenSeats[Index[0]][Index[1]] == "taken")
                                    {
                                        Index[1]++;
                                    }
                                }
                            }
                        }
                    }
                }
                DrawSeats();
            }
            while (key.Key != ConsoleKey.Escape);
            return 0;
        }


	// This function handles drawing the seats, if the seat is taken
	// it will draw a red 'x' between the brackets, otherwise it will
	// have have a space between them
        public void DrawSeat(string status, bool selected)
        {
            if (status == "taken")
            {
                if (selected)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("[ ]");
                }

                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write("[ ]");
                }
            }
	    else if (status == "chosen")
            {
                if (selected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("x");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.White;
		    Console.Write("]");
                }
                else
                {
		    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("x");
                    Console.ResetColor();
		    Console.Write("]");
                }
            }
	    else if (status == null)
            {
                if (selected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("[ ]");
                }
                else
                {
		    Console.Write("[ ]");
                }
            }
            Console.ResetColor();
        }
    }
}

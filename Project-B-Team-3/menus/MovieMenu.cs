using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class MovieSelection
    {
        public int Index;
        public string[][] movies = new string[][]{
                new string[]{"Spider-Man",
                    "Voor de allereerste keer in de geschiedenis van de Spider-Man films\n" +
                    "is onze vriendelijke superheld ontmaskerd en kan hij zijn normale\n" +
                    "leven niet langer gescheiden houden van zijn gevaarlijke leven als superheld.\n",  "Actie en Avontuur\n"},
                new string[]{"Uncharted",
                    "In dit spectaculaire actie-avontuur maken Nathan Drake (Tom Holland)\n" +
                    "en Victor “Sully” Sullivan (Mark Wahlberg) een gevaarlijke reis om de\n" +
                    "wereld op zoek naar ‘de grootste schat die nooit is gevonden’ en komen\n" +
                    "zo tegelijkertijd op het spoor van Nathans vermiste broer.", "Actie en Avontuur\n"},
                new string[]{"The Batman",
                    "Het is meer dan een oproep… Het is een waarschuwing. Warner Bros. Pictures\n" +
                    "presenteert The Batman van regisseur Matt Reeves, met in de hoofdrol\n" +
                    "Robert Pattinson als Gotham City’s bekende misdaadbestrijder en zijn alter\n" +
                    "ego, de teruggetrokken miljardair Bruce Wayne.", "Actie, Misdaad en Drama"}

            };
        private void DisplayMenu()
        {
            Console.Clear();


            api.PrintCenter("<<*Movie Selection Menu*>>", 2);
            int j = 5;
            for (int i = 0; i < movies.Length; i++)
            {
                Console.SetCursorPosition(0, j + 1);
                Console.WriteLine("Discription: ", j + 1);
                Console.SetCursorPosition(0, j + 2);
                Console.WriteLine(movies[i][1]);

                j = j + 5 + movies[i][1].Length / 70;


            }

        }
        public void FirstRender()
        {
            DisplayMenu();
            int j = 5;
            for (int i = 0; i < movies.Length; i++)
            {
                if (i == Index)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.SetCursorPosition(0, j);
                    Console.WriteLine($"Title: {movies[i][0]} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.SetCursorPosition(0, j);
                    Console.WriteLine($"Title: {movies[i][0]} ");
                    Console.ResetColor();
                }

                j = j + 5 + movies[i][1].Length / 70;

            }
        }
        public int Run()
        {
            int p = 0;
            Console.Clear();
            FirstRender();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (Index != movies.Length - 1)
                    {
                        Index++;
                    }
                    if (p < movies.Length * 10)
                    {
                        p = p + 15;
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow && Index != -1)
                {
                    if (Index != 0)
                    {
                        Index--;
                    }
                    if (p > 0)
                    {
                        p = p - 15;
                    }
                }

                int j = 5;
                for (int i = 0; i < movies.Length; i++)
                {
                    if (i == Index)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.SetCursorPosition(0, j);
                        Console.WriteLine($"Title: {movies[i][0]} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.SetCursorPosition(0, j);
                        Console.WriteLine($"Title: {movies[i][0]} ");
                        Console.ResetColor();
                    }

                    j = j + 5 + movies[i][1].Length / 70;

                }
                Console.SetCursorPosition(0, p);
            } while (key.Key != ConsoleKey.Escape);

            return 0;
        }
    }
}

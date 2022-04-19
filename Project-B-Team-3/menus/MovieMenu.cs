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
                new string[]{"Spider-Man0",
                    "Voor de allereerste keer in de geschiedenis van de Spider-Man films\n" +
                    "is onze vriendelijke superheld ontmaskerd en kan hij zijn normale\n" +
                    "leven niet langer gescheiden houden van zijn gevaarlijke leven als superheld.\n",  "Actie en Avontuur\n" },
                new string[]{"Spider-Man0",
                    "Voor de allereerste keer in de geschiedenis van de Spider-Man films\n" +
                    "is onze vriendelijke superheld ontmaskerd en kan hij zijn normale\n" +
                    "leven niet langer gescheiden houden van zijn gevaarlijke leven als superheld.\n",  "Actie en Avontuur\n" },
                new string[]{"Spider-Man0",
                    "Voor de allereerste keer in de geschiedenis van de Spider-Man films\n" +
                    "is onze vriendelijke superheld ontmaskerd en kan hij zijn normale\n" +
                    "leven niet langer gescheiden houden van zijn gevaarlijke leven als superheld.\n",  "Actie en Avontuur\n" },
                new string[]{"Spider-Man0",
                    "Voor de allereerste keer in de geschiedenis van de Spider-Man films\n" +
                    "is onze vriendelijke superheld ontmaskerd en kan hij zijn normale\n" +
                    "leven niet langer gescheiden houden van zijn gevaarlijke leven als superheld.\n",  "Actie en Avontuur\n" },
                new string[]{"Spider-Man0",
                    "Voor de allereerste keer in de geschiedenis van de Spider-Man films\n" +
                    "is onze vriendelijke superheld ontmaskerd en kan hij zijn normale\n" +
                    "leven niet langer gescheiden houden van zijn gevaarlijke leven als superheld.\n",  "Actie en Avontuur\n" },
                new string[]{"Spider-Man0",
                    "Voor de allereerste keer in de geschiedenis van de Spider-Man films\n" +
                    "is onze vriendelijke superheld ontmaskerd en kan hij zijn normale\n" +
                    "leven niet langer gescheiden houden van zijn gevaarlijke leven als superheld.\n",  "Actie en Avontuur\n" },
                new string[]{"Spider-Man0",
                    "Voor de allereerste keer in de geschiedenis van de Spider-Man films\n" +
                    "is onze vriendelijke superheld ontmaskerd en kan hij zijn normale\n" +
                    "leven niet langer gescheiden houden van zijn gevaarlijke leven als superheld.\n",  "Actie en Avontuur\n" }

            };
        private void DisplayMenu(int start, int end, int pagenumber)
        {
            Console.Clear();


            api.PrintCenter("<<*Movie Selection Menu*>>", 1);
            api.PrintCenter("ARROW - Select movie | ENTER - Comfirm movie | ESCAPE - Exit", 28);
            if (movies.Length % 3 != 0)
            {
                api.PrintCenter("Page " + pagenumber + "/" + ((movies.Length / 3) + 1), 2);
            }
            else
            {
                api.PrintCenter("Page " + pagenumber + "/" + (movies.Length / 3), 2);

            }
            int j = 5;
            for (int i = start; i < end; i++)
            {
                Console.SetCursorPosition(0, j + 1);
                Console.WriteLine("Discription: ", j + 1);
                Console.SetCursorPosition(0, j + 2);
                Console.WriteLine(movies[i][1]);

                j = j + 5 + movies[i][1].Length / 80;


            }

        } 
        public void FirstRender(int start, int end, int pagenumber)
        {
            int j = 5;


            if (end > movies.Length)

            {
                end = movies.Length;
            }

            DisplayMenu(start, end, pagenumber);

            for (int i = start; i < end; i++)
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

                j = j + 5 + movies[i][1].Length / 80;

            }
        }
        public int Run()
        {
            int pagenumber = 1;
            int page = 0;
            int start = 0;
            int end = 3;
            if (end > movies.Length)

            {
                end = movies.Length;
            }

            Console.Clear();
            FirstRender(start, end, pagenumber);
            ConsoleKeyInfo key;
            do
            {
                int p = 0;
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow && Index != end - 1)
                {
                    if (Index < end - 1)
                    {
                        Index++;
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow && Index != -1)
                {
                    if (Index > page)
                    {
                        Index--;
                    }
                }
                else if (key.Key == ConsoleKey.LeftArrow && start > 0)
                {

                    
                    start -= 3;
                    pagenumber--;
                    page = page - 3;
                    Index = page;
                    if (end % 3 == 0)
                    {
                        end = end - 3;
                    }
                    else
                    {
                        end = end - (end % 3);
                    }
                    Console.Clear();
                    FirstRender(start, end, pagenumber);
                    if (end > movies.Length)

                    {
                        end = movies.Length;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow && end < movies.Length)
                {
                    page = page + 3;
                    pagenumber++;
                    Index = page;
                    start += 3;
                    end += 3;
                    Console.Clear();
                    FirstRender(start, end, pagenumber);
                    if (end > movies.Length)

                    {
                        end = movies.Length;
                    }
                }
                int j = 5;



                for (
                    int i = start; i < end; i++)
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

                    j = j + 5 + movies[i][1].Length / 80;

                }
                Console.SetCursorPosition(0, p);
            } while (key.Key != ConsoleKey.Escape);

            return 0;
        }
    }
}

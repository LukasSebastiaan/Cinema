using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class CreateReview
    {
        private int Index = 0;
        private List<api.BigTextbox> Reviews = new List<api.BigTextbox>();
        private api.ConditionalTextbox Rating;

        public CreateReview()
        {
            Reviews.Add(new api.BigTextbox("Review", 1, (Console.WindowWidth - 20) / 2 - 30, 11, space_allowed : true,  width : 80, length : 3));
            Rating = new api.ConditionalTextbox("Rating (1-5)", 0, (Console.WindowWidth - 20) / 2 - 30, 9, 1, 1);
        }

        public void FirstRender()
        {
            api.PrintCenter("Hopefully you enjoyed our service.", 6);
            api.PrintCenter("Write a review for our cinema:", 7);
            DrawTextBoxes();
        }

        public void DrawTextBoxes()
        {
            foreach (api.BigTextbox box in Reviews)
            {
                box.Display(Index);
            }
            Rating.Display(Index);
        }

        public int Run()
        {
            Console.Clear();
            FirstRender();
            ConsoleKey keyPressed;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.Enter)
                {
                    if (Rating.Input == "")
                    {
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("ERROR:  No rating given", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        Console.Beep(100, 100);
                    }
                    else if (Reviews[0].Input == "")
                    {
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("ERROR:  No review has been written", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        Console.Beep(100, 100);
                    }
                    else
                    {
                        var NewReview = new ReviewsList();
                        NewReview.Add(Reviews[0].Input, int.Parse(Rating.Input));
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("Thank you for your review", 4, ConsoleColor.Black, ConsoleColor.Green);
                        Thread.Sleep(2000);
                        return 0;
                    }
                }
                else if (keyPressed == ConsoleKey.Tab || keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.UpArrow)
                {
                    if (Index > 0)
                    {
                        Index--;
                    }
                    else if (Index < 1)
                    {
                        Index++;
                    }
                    else
                    {
                        Index = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.Backspace)
                {
                    if (Index == 0)
                    {
                        Rating.Backspace();
                    }
                    else
                    {
                        Reviews[0].Backspace();
                    }
                    DrawTextBoxes();
                }

                if (Index == 0 && int.TryParse(keyInfo.KeyChar.ToString(), out int number))
                {
                    if (number > 5)
                    {
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("ERROR:  Not a valid rating", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                    }
                    else
                    {
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        Rating.AddLetter(keyInfo.KeyChar);
                    }
                }

                if (Index == 1 && Reviews[0].Input.Length < 210)
                {
                    Reviews[0].AddLetter(keyInfo.KeyChar);
                }

                DrawTextBoxes();
            }
            while (keyPressed != ConsoleKey.Escape);
            return 0;
        }
    }
}

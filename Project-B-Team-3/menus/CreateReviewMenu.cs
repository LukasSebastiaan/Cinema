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

        public CreateReview()
        {
            Reviews.Add(new api.BigTextbox("Review", 0, (Console.WindowWidth - 20) / 2 - 10, 9, true));
        }

        public void FirstRender()
        {
            api.PrintCenter("Hopefully you enjoyed our service.", 6);
            api.PrintCenter("Write a review for our cinema:", 7);
            DrawTextBox();
        }

        public void DrawTextBox()
        {
            foreach (api.BigTextbox box in Reviews)
            {
                box.Display(Index);
            }
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

                if (keyPressed == ConsoleKey.Escape)
                {
                    return 0;
                }

                if (keyPressed == ConsoleKey.Enter)
                {
                    if (Reviews[0].Input == "")
                    {
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("ERROR:  No review has been written", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        Console.Beep(100, 100);
                    }
                    else
                    {
                        var NewReview = new ReviewsList();
                        NewReview.Add(Reviews[0].Input);
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("Thank you for your review", 4, ConsoleColor.Black, ConsoleColor.Green);
                        Thread.Sleep(2000);
                    }
                }

                if (Index < Reviews.Count)
                {
                    if (keyPressed == ConsoleKey.Backspace)
                    {
                        Reviews[Index].Backspace();
                    }
                    else
                    {
                        if (Reviews[0].Input.Length < 210)
                        {
                            Reviews[Index].AddLetter(keyInfo.KeyChar);
                        }
                    }
                }

                DrawTextBox();
            }
            while (keyPressed != ConsoleKey.Enter);
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class ReviewMenu
    {
        private int Index;
        private string Prompt;
        private List<api.Button> Buttons = new List<api.Button>();

        private void DrawButtons()
        {
            foreach (api.Button Button in Buttons)
            {
                Button.Display(Index);
            }
        }
        public ReviewMenu()
        {
            Buttons.Add(new api.Button("Place review", 0, 32, 17));
            Buttons.Add(new api.Button("See reviews", 1, 51, 17));
        }
        private void DisplayOptions()
        {
            DrawButtons();
        }
        
        public int Run()
        {
            ConsoleKey keyPressed;
            Console.Clear();
            DisplayOptions();
            do
            {

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.Escape)
                    return 2;

                if (keyPressed == ConsoleKey.RightArrow)
                {
                    Index++;
                    if (Index > Buttons.Count - 1)
                    {
                        Index = 0;
                    }

                }
                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    Index--;
                    if (Index < 0)
                    {
                        Index = Buttons.Count - 1;
                    }
                }
                DrawButtons();
            } while (keyPressed != ConsoleKey.Enter);
            return Index;
        }
        public void PlaceReview()
        {
            string strReview = "";
            int counter = 0;
            Console.Clear();
            Console.WriteLine("Hopefully you enjoyed our service.\n\nWrite a review for our cinema:\n\n");
            strReview = Console.ReadLine();
            while (counter == 0)
            {
                if (string.IsNullOrEmpty(strReview))
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong.\n\nPlease write a review for our cinema: \n");
                    strReview = Console.ReadLine();
                }
                else
                {
                    counter++;
                }
            }
            Console.Clear();
            Console.WriteLine("Thank you for your feedback.\n\nSee your review here:\n\n" + strReview);
            Console.ReadKey(true);
            Run();
        }
    }
}

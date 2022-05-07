using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{

    internal class CreateReview
    {
        //private List<api.Textbox> ReviewInfo = new List<api.Textbox>();

        private void FirstRender()
        {
            api.PrintCenter("Hopefully you enjoyed our service.", 6);
            api.PrintCenter("Write a review for our cinema:", 7);
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            Console.Clear();
            FirstRender();
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.Escape)
                {
                    return 0;
                }

                string strReview = "";
                int counter = 0;
                strReview = Console.ReadLine();
                while (counter == 0)
                {
                    if (string.IsNullOrEmpty(strReview))
                    {
                        api.PrintCenter("Something went wrong. Please write a review for our cinema:", 9, ConsoleColor.Black, ConsoleColor.DarkRed);
                        strReview = Console.ReadLine();
                    }
                    else
                    {
                        counter++;
                    }
                }
                Console.Clear();
                api.PrintCenter("Thank you for your feedback.", 10, ConsoleColor.Black, ConsoleColor.Green);
                api.PrintCenter("See your review here:", 12);
                api.PrintCenter(strReview, 13);
                // opslaan review
                api.PrintCenter("Press Enter to continue", 17);
                Console.ReadKey(true);
            }
            while (keyPressed == ConsoleKey.Enter);
            return 0;
        }
    }
}

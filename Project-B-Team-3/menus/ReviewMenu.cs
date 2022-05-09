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

        public ReviewMenu()
        {
            Buttons.Add(new api.Button("Place review", 0, 32, 17));
            Buttons.Add(new api.Button("See reviews", 1, 51, 17));
        }

        private void DrawButtons()
        {
            foreach (api.Button Button in Buttons)
            {
                Button.Display(Index);
            }
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
                {
                    return 0;
                }

                if (keyPressed == ConsoleKey.Enter)
                {
                    if (Index == 0 && Program.information.Member == null)
                    {
                        api.PrintCenter("    You haven't logged in to an account yet.    ", 8, foreground: ConsoleColor.DarkRed);
                        Thread.Sleep(1500);
                        return 3;
                    }
                }

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
            }
            while (keyPressed != ConsoleKey.Enter);
            return Index+1;
        }
    }
}

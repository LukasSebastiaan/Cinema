using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class Welcome
    {
        private int Index;
        private string Prompt;
        private List<api.Button> Buttons = new List<api.Button>();

        public Welcome(string prompt, int index)
        {
            Prompt = prompt;
            Index = index;

            Buttons.Add(new api.Button("Choose Film", 0, 32, 17));
            Buttons.Add(new api.Button("Login", 1, 51, 17));
            Buttons.Add(new api.Button("Register", 2, 64, 17));
            Buttons.Add(new api.Button("Reviews", 3, 79, 17));

        }

        private void FirstRender()
        {

            Console.SetCursorPosition(0, 8);
            Console.WriteLine(Prompt);

            DrawButtons();

            string footer = "ARROW KEYS - select options  |  ENTER - Confirm  |  ESCAPE - Exit";
            Console.SetCursorPosition((Console.WindowWidth - footer.Length) / 2, 28);
            Console.WriteLine(footer);
        }

        private void DrawButtons()
        {
            foreach (api.Button Button in Buttons)
            {  
                Button.Display(Index);
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
                    return 4;
                }
                if (keyPressed == ConsoleKey.F12)
                {
                    return 42069;
                }

                if (keyPressed == ConsoleKey.RightArrow)
                {
                    Index++;
                    if (Index > Buttons.Count-1)
                    {
                        Index = 0;
                    }

                }
                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    Index--;
                    if (Index < 0)
                    {
                        Index = Buttons.Count-1;
                    }
                }
                DrawButtons();

            } while (keyPressed != ConsoleKey.Enter);

            return Index;
        }
    }
}

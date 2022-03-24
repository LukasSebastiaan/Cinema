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
        private string[] Options;
        private string Prompt;

        public Welcome(string prompt, string[] options, int index)
        {
            Prompt = prompt;
            Options = options;
            Index = index;
        }

        private void FirstRender()
        {

            Console.SetCursorPosition(0, 8);

            Console.WriteLine(Prompt);

            DrawBoxes();

            string footer = "ARROW KEYS - select options  |  ENTER - Confirm  |  ESCAPE - Exit";
            Console.SetCursorPosition((Console.WindowWidth - footer.Length) / 2, 28);
            Console.WriteLine(footer);
        }

        private void DrawBoxes()
        {
            Console.SetCursorPosition(26, 17);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];

                if (i == Index)
                {
                    string s = $" {currentOption} ";
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(s);
                    Console.ResetColor();
                }
                else
                {
                    string s = $" {currentOption} ";
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write(s);
                    Console.ResetColor();


                }
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

                if (keyPressed == ConsoleKey.RightArrow)
                {
                    Index++;
                    if (Index > Options.Length-1)
                    {
                        Index = 0;
                    }

                }
                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    Index--;
                    if (Index < 0)
                    {
                        Index = Options.Length-1;
                    }
                }
                DrawBoxes();

            } while (keyPressed != ConsoleKey.Enter);

            return Index;
        }
    }
}
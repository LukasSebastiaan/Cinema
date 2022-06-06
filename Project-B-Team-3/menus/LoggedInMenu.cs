using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class LoggedInMenu : structure
    {
        private int Index;
        private List<api.Button> Buttons;

        public LoggedInMenu()
        {
            Index = 1;

            Buttons = api.Button.CreateRow(new string[] { "Choose Film", "View Reservations", "Reviews", "Logout" }, 3, 17);
        }

        public void FirstRender()
        {
            api.PrintCenter($"Welcome back {Program.information.Member.Firstname}", 12);

            DrawButtons();

            string footer = "ARROW KEYS - select options  |  ENTER - Confirm";
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

            if (Index == 3)
            {
                var info = Program.information;
                info.Member = null;
                Program.information = info;
                return -1;
            }
            
            return Index;
        }
    }
}

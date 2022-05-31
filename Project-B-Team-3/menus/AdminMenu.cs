﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class AdminMenu
    {
        private int Index;
        private string Prompt;
        private List<api.Button> Buttons = new List<api.Button>();

        public AdminMenu()
        {
            Index = 1;

            int x = Console.WindowWidth / 2 - ((22 + 18) / 2);
            Buttons = api.Button.CreateRow(new string[] { "Movies", "Reviews", "Earnings", "Logout" }, 5, 17);
        }

        private void FirstRender()
        {
            api.PrintCenter("Welcome back admin! What do you wish to do?", 11);

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

            if (Index == 3) {
                var info = Program.information;
                info.Member = null;
                Program.information = info;
                return 0;
            }
            
            return Index+1;
        }

    }
}

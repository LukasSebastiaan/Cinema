using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class Register
    {
/*        public string First_name = "";
        public string Last_name = "";
        public string Email = "";
        public string Password = "";
        public string Creditcard = "";*/
        private int Index = 0;
        private List<api.Textbox> Credentials = new List<api.Textbox>();

        public Register()
        {
            Credentials.Add(new api.Textbox("Firstname: ", 0, (Console.WindowWidth - 20) / 2, 4, false));
            Credentials.Add(new api.Textbox("Lastname: ", 1, (Console.WindowWidth - 20) / 2, 6, false));
            Credentials.Add(new api.Textbox("Email: ", 2, (Console.WindowWidth - 20) / 2, 8, false));
            Credentials.Add(new api.Textbox("Password: ", 3, (Console.WindowWidth - 20) / 2, 11, true));
            Credentials.Add(new api.ConditionalTextbox("Creditcard: ", 4, (Console.WindowWidth - 20) / 2, 13, 16, 16));
        }

        private void DisplayMenu()
        {
            Console.Clear();
            api.PrintCenter("First name:", 3);
            api.PrintCenter("Last name:", 5);
            api.PrintCenter("Email:", 7);
            api.PrintCenter("Password:", 9);
            api.PrintCenter("- Make sure u have at least:\n- Included a special character\n- Included a number :", 10);
            api.PrintCenter("Creditcard:", 12);

            DrawTextBoxes();

            string footer = "ARROW KEYS OR Tab - Chance box  |  ENTER - Finish  |  ESCAPE - Go back";
            Console.SetCursorPosition((Console.WindowWidth - footer.Length) / 2, 28);
            Console.WriteLine(footer);
        }
        private void DrawTextBoxes()
        {
            foreach (api.Textbox Field in Credentials)
            {
                Field.Display(Index);
            }
        }

        public int Run()
        {
            Console.Clear();
            ConsoleKey keyPressed;
            DisplayMenu();
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                
                if (keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.Tab)
                {
                    Index++;
                }
                else if(keyPressed == ConsoleKey.UpArrow)
                {
                    Index--;
                }
                else if (keyPressed == ConsoleKey.Backspace)
                {
                    Credentials[Index].Backspace();
                    DrawTextBoxes();
                }

                if (Index < Credentials.Count)
                {
                    if (Index == 4)
                    {
                        if (int.TryParse(keyInfo.KeyChar.ToString(), out int number))
                        {
                            Credentials[Index].AddLetter(keyInfo.KeyChar);
                        }
                    }
                    else
                    {
                        Credentials[Index].AddLetter(keyInfo.KeyChar);
                    }
                }

                DrawTextBoxes();
            }
            while (keyPressed != ConsoleKey.Enter);

            return 0;
        }
    }
}

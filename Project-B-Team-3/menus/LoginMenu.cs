using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ProjectB
{
    internal class LoginMenu
    {
        public int Run()
        {
            Console.Clear();
            ConsoleKeyInfo key;
            api.PrintCenter("Login", 10);
            var emailTextBox = new api.Textbox("Voer E-mail in", 1, 50, 14);
            var passwordTextBox = new api.Textbox("Voer wachtwoord in", 2, 50, 16, true);
            emailTextBox.Display(1);
            passwordTextBox.Display(2);
            int textboxIndex = 1;
            string footer = "ARROW KEYS / TAB - Change box  |  ENTER - Finish  |  ESCAPE - Go back";
            Console.SetCursorPosition((Console.WindowWidth - footer.Length) / 2, 28);
            Console.WriteLine(footer);
            do
            {
                key = Console.ReadKey(true);
                if (textboxIndex == 1)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        emailTextBox.Backspace();
                        emailTextBox.Display(1);
                    }
                    else
                    {
                        emailTextBox.AddLetter(key.KeyChar);
                        emailTextBox.Display(1);
                    }
                }
                if (textboxIndex == 2)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        passwordTextBox.Backspace();
                        passwordTextBox.Display(2);
                    }
                    else
                    {
                        passwordTextBox.AddLetter(key.KeyChar);
                        passwordTextBox.Display(2);
                    }
                }
                if (key.Key == ConsoleKey.Tab || key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.UpArrow)
                {
                    if(textboxIndex == 1)
                    {
                        textboxIndex = 2;
                    }
                    else if(textboxIndex == 2)
                    {
                        textboxIndex = 1;
                    }

                }
            }
            while (key.Key != ConsoleKey.Escape);
            return 0;
        }
    }
}

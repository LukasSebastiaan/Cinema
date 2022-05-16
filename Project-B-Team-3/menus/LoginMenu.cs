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
        private int Index;
        private List<api.Textbox> Textboxes = new List<api.Textbox>();
        public List<Account> accountList;
        AccountHandler Accounts = new AccountHandler();

	    public LoginMenu()
	    {
            Index = 0;
	    
            Textboxes.Add(new api.Textbox("E-mail", 0, (Console.WindowWidth - 20) / 2, 14));
            Textboxes.Add(new api.Textbox("Password", 1, (Console.WindowWidth - 20) / 2, 16, hidden: true));

        }

        public void FirstRender()
	    {
            api.PrintCenter("Login", 12);
	        string footer = "ARROW KEYS/TAB - Change box  |  CTRL+ENTER - Change password  |  ENTER - Finish  |  ESCAPE - Go back";
	        Console.SetCursorPosition((Console.WindowWidth - footer.Length) / 2, 28);
            Console.WriteLine(footer);
            DisplayTextboxes();
        }

        public void DisplayTextboxes()
        {
            foreach (var textbox in Textboxes)
            {
                textbox.Display(Index);
            }
        }

        public int Run()
        {
            Console.Clear();
            FirstRender();
            var info = Program.information;
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                ConsoleKey keyPressed = key.Key;

                
		
                if (keyPressed == ConsoleKey.Tab || keyPressed == ConsoleKey.DownArrow)
                {
                    if (Index < Textboxes.Count-1)
                    {
                        Index++;
                    }
                    else
                    {
                        Index = 0;
                    }
                }
		        else if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (Index > 0)
                    {
                        Index--;
                    }
                }

                if (Index < Textboxes.Count)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        Textboxes[Index].Backspace();
                    }
                    else
                    {
                        Textboxes[Index].AddLetter(key.KeyChar);
                    }
                }

                if (key.Modifiers.HasFlag(ConsoleModifiers.Control) & keyPressed == ConsoleKey.Enter)
                {
                    return 3;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    var account = Accounts.Exists(Textboxes[0].Input, Textboxes[1].Input);
                    if (account != null)
                    {
                        if(Textboxes[0].Input.Equals("admin") && Textboxes[1].Input.Equals("admin"))
                        {
                            info.Member = account;
                            Program.information = info;
                            return 2;

                        }

                        info.Member = account;
                        Program.information = info;
                        return 1;
                    }
                    else
                    {
                        api.PrintCenter("Invalid email or password!", 18, foreground: ConsoleColor.DarkRed);
                    }
                }

                DisplayTextboxes();
            }
            while (key.Key != ConsoleKey.Escape);
            return 0;
        }
    }
}

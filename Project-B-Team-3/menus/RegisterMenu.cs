using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class Register
    {
        public string First_name = "";
        public string Last_name = "";
        public string Email = "";
        public string Password = "";
        public string Creditcard = "";
        private int Index = 0;
        private List<api.Textbox> Credentials = new List<api.Textbox>();

        public Register()
        {
            Credentials.Add(new api.Textbox("Firstname: ", 0, (Console.WindowWidth - 20) / 2, 7));
            Credentials.Add(new api.Textbox("Lastname: ", 1, (Console.WindowWidth - 20) / 2, 10));
            Credentials.Add(new api.Textbox("Email: ", 2, (Console.WindowWidth - 20) / 2, 13));
            Credentials.Add(new api.Textbox("Password: ", 3, (Console.WindowWidth - 20) / 2, 16, true));
            Credentials.Add(new api.ConditionalTextbox("Creditcard: ", 4, (Console.WindowWidth - 20) / 2, 19, 16, 16));
        }

        private bool CheckAccount(string Email)
        {
            AccountList Accounts = new AccountList();
            Accounts.Load();
            for (int i = 0; i < Accounts.Accounts.Count; i++)
            {
                if (Credentials[2].Input == Accounts.Accounts[i].Email)
                {
                    return false;
                }
            }
            return true;
        }

        private void DisplayMenu()
        {
            Console.Clear();
            api.PrintCenter("First name:", 6);
            api.PrintCenter("Last name:", 9);
            api.PrintCenter("Email:", 12);
            api.PrintCenter("Password:", 15);
            api.PrintCenter("Creditcard:", 18);

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
                if (keyPressed == ConsoleKey.Enter)
                {
                    if (Credentials[0].Input == "")
                    {

                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("ERROR:  Firstname empty", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        Console.Beep(100, 100);
                    }
                    else if (Credentials[1].Input == "")
                    {
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("ERROR:  Lastname empty", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        Console.Beep(100, 100);
                    }
                    else if (Credentials[2].Input == "")
                    {
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter(" ERROR:  Email empty", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        Console.Beep(100, 100);
                    }
                    else if (Credentials[3].Input == "")
                    {
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("ERROR:  Password empty", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        Console.Beep(100, 100);
                    }
                    else if (Credentials[4].Input.Length < 16)
                    {
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("ERROR:  Creditcard has less than 16 numbers", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        Console.Beep(100, 100);
                    }
                    else
                    {
                        if (CheckAccount(Email))
                        {
                            var Accounts = new AccountList();
                            Accounts.Load();
                            Accounts.Accounts.Add(new Account() { Firstname = Credentials[0].Input, Lastname = Credentials[1].Input, Creditcard = Credentials[4].Input, Email = Credentials[2].Input, Password = Credentials[3].Input });
                            Accounts.Save();

                            SendEmail.SendVerifyEmail(Credentials[2].Input);
                            return 0;
                        }
                        else
                        {
                            api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                            api.PrintCenter("ERROR:  Email already exists!", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        }
                        

                    }
                }

                if ((keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.Tab) && Index != 4)
                {
                    Index++;
                }
                else if(keyPressed == ConsoleKey.UpArrow && Index != 0)
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
            while (keyPressed != ConsoleKey.Escape);

            return 0;
        }
    }
} 
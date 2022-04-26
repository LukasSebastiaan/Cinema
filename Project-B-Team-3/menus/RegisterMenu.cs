﻿using System;
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
        private AccountHandler accounthandler = new AccountHandler();

        public Register()
        {
            Credentials.Add(new api.Textbox("Firstname: ", 0, (Console.WindowWidth - 20) / 2, 7));
            Credentials.Add(new api.Textbox("Lastname: ", 1, (Console.WindowWidth - 20) / 2, 10, true));
            Credentials.Add(new api.Textbox("Email: ", 2, (Console.WindowWidth - 20) / 2, 13));
            Credentials.Add(new api.Textbox("Password: ", 3, (Console.WindowWidth - 20) / 2, 16, false, true));
            Credentials.Add(new api.Textbox("Confirm Password: ", 4, (Console.WindowWidth - 20) / 2, 19, false, true));
            Credentials.Add(new api.ConditionalTextbox("Creditcard: ", 5, (Console.WindowWidth - 20) / 2, 22, 16, 16));
        }

        private void DisplayMenu()
        {
            Console.Clear();
            api.PrintCenter("First name:", 6);
            api.PrintCenter("Last name:", 9);
            api.PrintCenter("Email:", 12);
            api.PrintCenter("Password:", 15);
            api.PrintCenter("Confirm Password:", 18);
            api.PrintCenter("Creditcard:", 21);

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
                    else if (Credentials[4].Input == "")
                    {
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("ERROR:  Confirm Password empty", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        Console.Beep(100, 100);
                    }
                    else if (Credentials[5].Input.Length < 16)
                    {
                        api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        api.PrintCenter("ERROR:  Creditcard has less than 16 numbers", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        Console.Beep(100, 100);
                    }
                    else
                    {
                        if (SendEmail.IsValidEmail(Credentials[2].Input) && accounthandler.EmailExists(Credentials[2].Input) && accounthandler.PasswordCheck(Credentials[3].Input,Credentials[4].Input))
                        {
                            api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                            api.PrintCenter("Verification email has been sent", 4, ConsoleColor.Black, ConsoleColor.Green);

                            int VerifyCode = SendEmail.Captcha(); // Generates verification code
                            var Dict = new Dictionary<string, string>() { {"{{Code}}", VerifyCode.ToString() } }; // Defined vars to be replaced in mail template
                            SendEmail.SendVerifyEmail(Credentials[2].Input, "htmlBodyRegister.txt", Dict); // Sends the email

                            var Accounts = new AccountHandler();
                            Accounts.Add(Credentials[0].Input, Credentials[1].Input, Credentials[2].Input, Credentials[3].Input, Credentials[5].Input); // Firstname, lastname, Email, Creditcard

                            return 0;
                        }
                        else if (accounthandler.PasswordCheck(Credentials[3].Input, Credentials[4].Input) == false) // Checks: if password and confirm password matches
                        {
                            api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                            api.PrintCenter("ERROR:  Passwords do not match!", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        }
                        else if(accounthandler.EmailExists(Credentials[2].Input) == false) // Checks: if email already exists
                        {
                            api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                            api.PrintCenter("ERROR:  Email already exists!", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        }
                        else
                        {
                            api.PrintExact(" ".PadRight(Console.WindowWidth), 0, 4, ConsoleColor.Black, ConsoleColor.DarkRed); // Error message: email is does not have a valid format
                            api.PrintCenter("ERROR:  Email is not valid!", 4, ConsoleColor.Black, ConsoleColor.DarkRed);
                        }
                    }
                }

                if ((keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.Tab) && Index != 5)
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
                    if (Index == 5)
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
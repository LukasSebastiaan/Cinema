namespace ProjectB
{
    internal class Foodmenu
    {
        private int[] Index = new int[] { 1, 0 };
        private List<api.Component> Components = new List<api.Component>();
        private const int OFFSET = 0;

        private int Popcorn_Small = 0;
        private int Popcorn_Medium = 0;
        private int Popcorn_Large = 0;
        private int Drinks_Small = 0;
        private int Drinks_Medium = 0;
        private int Drinks_Large = 0;

        private string Foodasccii = @"
 ______              _
|  ____|            | |
| |__ ___   ___   __| |
|  __/ _ \ / _ \ / _` |
| | | (_) | (_) | (_| |
|_|  \___/ \___/ \__,_|
";

        public Foodmenu()
        {
            //Components.Add(new api.Button("Do you want a small popcorn?",0, 1, 3));
            //Components.Add(new api.Button("Do you want a Medium popcorn?", 0, 1, 6));
        }

        public void FirstRender()
        {
            api.PrintCenter("Do you want food with your reservation?", 3);

            api.PrintCenter("Small Popcorn:  $2,50", 6, ConsoleColor.White, ConsoleColor.Black);

            api.PrintCenter("Medium Popcorn: $3,00", 9, ConsoleColor.White, ConsoleColor.Black);

            api.PrintCenter("Large Popcorn: $3,50", 12, ConsoleColor.White, ConsoleColor.Black);

            api.PrintCenter("Small Drink: $3,00", 15, ConsoleColor.White, ConsoleColor.Black);

            api.PrintCenter("Medium Drink: $3,00", 18, ConsoleColor.White, ConsoleColor.Black);

            api.PrintCenter("Large Drink: $3,50", 21, ConsoleColor.White, ConsoleColor.Black);

            DrawButtons();

            string footer = "ARROW KEYS - Change box  |  ENTER - Confirm  |  ESCAPE - Go back";
            Console.SetCursorPosition((Console.WindowWidth - footer.Length) / 2, 28);
            Console.WriteLine(footer);
        }

        public void DrawButtons()
        {
            foreach (var button in Components)
            {
                button.Display(Index[0]);
            }

            // Print Popcorn_Small
            if (Index[0] == 1)
            {
                api.PrintCenter($"{Popcorn_Small}".PadLeft(3).PadRight(5), 7, background: ConsoleColor.DarkGray, foreground: ConsoleColor.Black);
            }
            if (Index[0] != 1)
            {
                api.PrintCenter($"{Popcorn_Small}".PadLeft(3).PadRight(5), 7, background: ConsoleColor.Gray, foreground: ConsoleColor.Black);
            }
            // Print Popcorn_Medium
            if (Index[0] == 2)
            {
                api.PrintCenter($"{Popcorn_Medium}".PadLeft(3).PadRight(5), 10, background: ConsoleColor.DarkGray, foreground: ConsoleColor.Black);
            }
            if (Index[0] != 2)
            {
                api.PrintCenter($"{Popcorn_Medium}".PadLeft(3).PadRight(5), 10, background: ConsoleColor.Gray, foreground: ConsoleColor.Black);
            }
            // Print Popcorn_Large
            if (Index[0] == 3)
            {
                api.PrintCenter($"{Popcorn_Large}".PadLeft(3).PadRight(5), 13, background: ConsoleColor.DarkGray, foreground: ConsoleColor.Black);
            }
            if (Index[0] != 3)
            {
                api.PrintCenter($"{Popcorn_Large}".PadLeft(3).PadRight(5), 13, background: ConsoleColor.Gray, foreground: ConsoleColor.Black);
            }
            // Print Drinks_Small
            if (Index[0] == 4)
            {
                api.PrintCenter($"{Drinks_Small}".PadLeft(3).PadRight(5), 16, background: ConsoleColor.DarkGray, foreground: ConsoleColor.Black);
            }
            if (Index[0] != 4)
            {
                api.PrintCenter($"{Drinks_Small}".PadLeft(3).PadRight(5), 16, background: ConsoleColor.Gray, foreground: ConsoleColor.Black);
            }
            // Print Drinks_Medium
            if (Index[0] == 5)
            {
                api.PrintCenter($"{Drinks_Medium}".PadLeft(3).PadRight(5), 19, background: ConsoleColor.DarkGray, foreground: ConsoleColor.Black);
            }
            if (Index[0] != 5)
            {
                api.PrintCenter($"{Drinks_Medium}".PadLeft(3).PadRight(5), 19, background: ConsoleColor.Gray, foreground: ConsoleColor.Black);
            }
            // Print Drinks_Large
            if (Index[0] == 6)
            {
                api.PrintCenter($"{Drinks_Large}".PadLeft(3).PadRight(5), 22, background: ConsoleColor.DarkGray, foreground: ConsoleColor.Black);
            }
            if (Index[0] != 6)
            {
                api.PrintCenter($"{Drinks_Large}".PadLeft(3).PadRight(5), 22, background: ConsoleColor.Gray, foreground: ConsoleColor.Black);
            }

            //arrows Popcorn_Small
            api.PrintExact("<", Console.WindowWidth / 2 - 5, 7);
            api.PrintExact(">", Console.WindowWidth / 2 + 3, 7);

            //arrows Popcorn_Medium
            api.PrintExact("<", Console.WindowWidth / 2 - 5, 10);
            api.PrintExact(">", Console.WindowWidth / 2 + 3, 10);

            //arrows Popcorn_Large
            api.PrintExact("<", Console.WindowWidth / 2 - 5, 13);
            api.PrintExact(">", Console.WindowWidth / 2 + 3, 13);

            //arrows Drinks_Small
            api.PrintExact("<", Console.WindowWidth / 2 - 5, 16);
            api.PrintExact(">", Console.WindowWidth / 2 + 3, 16);

            //arrows Drinks_Medium
            api.PrintExact("<", Console.WindowWidth / 2 - 5, 19);
            api.PrintExact(">", Console.WindowWidth / 2 + 3, 19);

            //arrows Drinks_Large
            api.PrintExact("<", Console.WindowWidth / 2 - 5, 22);
            api.PrintExact(">", Console.WindowWidth / 2 + 3, 22);

            // calculate price: movieprice*amountofseats + popcornprice*amountofseats
            double total_price = (Popcorn_Small * 2.5) + (Popcorn_Medium * 3) + (Popcorn_Large * 3.5) + (Drinks_Small * 2.5) + (Drinks_Medium * 3) + (Drinks_Large * 3.5);
            api.PrintCenter($"    Total price: {total_price.ToString("#.##")}$    ", 23, foreground: ConsoleColor.Green);
        }

        public int Run()
        {
            Console.Clear();
            FirstRender();
            ConsoleKeyInfo key;

            do
            {
                var info = Program.information;
                key = Console.ReadKey(true);
                ConsoleKey keyPressed = key.Key;

                if (keyPressed == ConsoleKey.Enter)
                {
                    if (Index[1] == 0)
                    {
                        return -1;
                    }
                    if (Index[1] == 1)
                    {
                        return 1;
                    }
                }
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (Index[0] <= Components.Count)
                    {
                        Index[0]--;
                    }
                }
                if (keyPressed == ConsoleKey.DownArrow)
                {
                    if (Index[0] >= 0)
                    {
                        Index[0]++;
                    }
                }

                if (keyPressed == ConsoleKey.RightArrow)
                {
                    if (Index[0] == 0)
                    {
                        if (Popcorn_Small < 100)
                        {
                            Popcorn_Small++;
                        }
                    }
                    if (Index[0] == 1)
                    {
                        if (Popcorn_Medium < 100)
                        {
                            Popcorn_Medium++;
                        }
                    }
                    if (Index[0] == 2)
                    {
                        if (Popcorn_Large < 100)
                        {
                            Popcorn_Large++;
                        }
                        if (Index[0] == 3)
                        {
                            if (Drinks_Small < 100)
                            {
                                Drinks_Small++;
                            }
                        }
                        if (Index[0] == 4)
                        {
                            if (Drinks_Medium < 100)
                            {
                                Drinks_Medium++;
                            }
                        }
                        if (Index[0] == 5)
                        {
                            if (Drinks_Large < 100)
                            {
                                Drinks_Large++;
                            }
                        }
                        else
                        {
                            if (Index[1] < Components.Count - 1)
                            {
                                Index[1]++;
                            }
                            else
                            {
                                Index[1] = 0;
                            }
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.LeftArrow)
                {
                    if (Index[0] == 0)
                    {
                        if (Popcorn_Small > 0)
                        {
                            Popcorn_Small--;
                        }
                    }
                    if (Index[0] == 1)
                    {
                        if (Popcorn_Medium > 0)
                        {
                            Popcorn_Medium--;
                        }
                    }
                    if (Index[0] == 2)
                    {
                        if (Popcorn_Large > 0)
                        {
                            Popcorn_Large--;
                        }
                    }
                    if (Index[0] == 3)
                    {
                        if (Drinks_Small > 0)
                        {
                            Drinks_Small--;
                        }
                    }
                    if (Index[0] == 3)
                    {
                        if (Drinks_Small > 0)
                        {
                            Drinks_Small--;
                        }
                    }
                    if (Index[0] == 4)
                    {
                        if (Drinks_Medium > 0)
                        {
                            Drinks_Medium--;
                        }
                    }
                    if (Index[0] == 5)
                    {
                        if (Drinks_Large > 0)
                        {
                            Drinks_Large--;
                        }
                    }
                    else
                    {
                        if (Index[1] > 0)
                        {
                            Index[1]--;
                        }
                    }
                }
                DrawButtons();
            }
            while (key.Key != ConsoleKey.Escape);

            return 1;
        }
    }
}
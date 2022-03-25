using System;

namespace ProjectB
{
    class Program
    {
        static void Main(string[] args)
        {   
            // Settings for the console application
            Console.CursorVisible = false;
          

            Manager game = new Manager();
            game.Start();
        }
    }

    /// <summary>
    /// The class that contains
    public class api
    {
        /// <summary>
        /// Prints text in the middle of the screen at a specified y position
        /// </summary>
        /// <param name="text">text to write in the middle</param>
        /// <param name="y">The y position to write the text at</param>
        public static void PrintCenter(string text, int y)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, y);
            Console.WriteLine(text);
        }

        /// <summary>
        /// Prints something at a specific point on the screen
        /// </summary>
        /// <param name="text">The text to print</param>
        /// <param name="x">The x position</param>
        /// <param name="y">The y position. Aka the line to print on (counted from up to down)</param>
        /// <param name="Background">The background that the text will have. Use System.ConsoleColor.(colorname)</param>
        /// <param name="Foreground">The color the characters will have. Use System.ConsoleColor.(colorname)</param>
        public static void PrintExact(string text, int x, int y, ConsoleColor background, ConsoleColor foreground)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(text);
            Console.ResetColor();
        }


        /// <summary>
        /// Makes a text box that takes a string and displays it within an width of 20 characters
        /// Its recommended that you do not use this yet
        /// </summary>
        public static void Textbox(string placeholder, string input, int index, int current_index, int y_cord, bool hidden)
        {
            placeholder = placeholder.PadRight(20);

            if (input.PadRight(20) == "                    ")
            {
                if (index == current_index)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Gray;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                Console.SetCursorPosition((Console.WindowWidth - placeholder.Length) / 2, y_cord);
                Console.WriteLine(placeholder);


            }
            else
            {
                if (index == current_index)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                if (hidden)
                {
                    if (input.Length < 20)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, y_cord);
                        Console.WriteLine(new string('*', input.Length).PadRight(20));
                    }
                    else
                    {
                        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, y_cord);
                        Console.WriteLine(new string('*', input.Length).Remove(0, input.Length - 20));
                    }
                }
                else
                {
                    if (input.Length < 20)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, y_cord);
                        Console.WriteLine(input.PadRight(20));
                    }
                    else
                    {
                        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, y_cord);
                        Console.WriteLine(input.Remove(0, input.Length - 20));
                    }
                }
            }
            Console.ResetColor();
        }

        /// <summary>
        /// This is the same as a textbox, but stays red until a certain amount of string length is reached.
        /// Its not recommended to use this until its an actual class
        /// </summary>
        public static void ConditionalBox(string placeholder, string input, int index, int current_index, int min_char, int y_cord)
        {
            placeholder = placeholder.PadRight(20);

            if (input.PadRight(20) == "                    ")
            {
                if (index == current_index)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Gray;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                Console.SetCursorPosition((Console.WindowWidth - placeholder.Length) / 2, y_cord);
                Console.WriteLine(placeholder);


            }
            else
            {
                if (index == current_index)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    if (input.Length < min_char)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    if (input.Length < min_char)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }

                if (input.Length < 20)
                {
                    Console.SetCursorPosition((Console.WindowWidth - 20) / 2, y_cord);
                    Console.WriteLine(input.PadRight(20));
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth - 20) / 2, y_cord);
                    Console.WriteLine(input.Remove(0, input.Length - 20));
                }
            }
            Console.ResetColor();
        }   


        public class Button
        {
            private string Title;
            private int Index;
            private int X;
            private int Y;

            /// <summary>
            /// This button class draw a button on the screen.
            /// </summary>
            /// <param name="title">The text that will apear on the button</param>
            /// <param name="index">This is the index of the button. When the current index (given in the Draw() fuction) is the same as the index, then </param>
            /// <param name="x">The x cordinate where the left side of the button will begin</param>
            /// <param name="y">The y cordinate (line) where the button will be placed</param>
            public Button(string title, int index, int x, int y)
            {
                Title = title;
                Index = index;
                X = x;
                Y = y;
            }

            public void Display(int current_index)
            {
                if (Index == current_index)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                Console.SetCursorPosition(X, Y);
                Console.WriteLine($" {Title} ");
                Console.ResetColor();
            }

        }
    }
}
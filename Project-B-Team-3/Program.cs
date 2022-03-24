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

    // The API for used by the program
    public static class api
    {
        // Prints something in the center of the screen
        public static void PrintCenter(string text, int y)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, y);
            Console.WriteLine(text);
        }

        // Prints something at a given x,y and
        public static void PrintExact(string text, int x, int y, ConsoleColor background, ConsoleColor foreground)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void Button(string text, int x, int y, int index, int current_index)
        {
            if (index == current_index)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine($" {text} ");
            Console.ResetColor();

        }


        // Textbox class that displays a textbox 
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
        
        
    }
}
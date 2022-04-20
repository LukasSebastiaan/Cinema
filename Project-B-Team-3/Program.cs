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
        public static void PrintCenter(string text, int y, ConsoleColor background = ConsoleColor.Black, ConsoleColor foreground = ConsoleColor.White)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, y);
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints something at a specific point on the screen
        /// </summary>
        /// <param name="text">The text to print</param>
        /// <param name="x">The x position</param>
        /// <param name="y">The y position. Aka the line to print on (counted from up to down)</param>
        /// <param name="Background">The background that the text will have. Use System.ConsoleColor.(colorname)</param>
        /// <param name="Foreground">The color the characters will have. Use System.ConsoleColor.(colorname)</param>
        public static void PrintExact(string text, int x, int y, ConsoleColor background = ConsoleColor.Black, ConsoleColor foreground = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(text);
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

            /// <summary>
            /// Draws the button on the specified x and y coordinates
            /// </summary>
            /// <param name="current_index">It index the user is on at a specific screen</param>
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


	/* Voor de mensen die na GrandOmega hier naar kijken en denken: M.. m.. maar je zet geen *this.* voor alle variablen dus je verwijst niet
	 naar de instance van de class. Jawel, maar in .net (c#) is een variable automatisch een instance variable, dus hoef je dat niet ervoor te
	zetten. Als je een class variable wilt maken moet je er "static" voor stoppen, bijvoorbeeld: public static string ClassVariable*/

	
        public class Textbox
        {
            protected string Placeholder;
            public string Input = "";
            protected int Index;
            protected int X;
            protected int Y;
            protected bool Hidden;

            protected char[] allowed = "abcdefghijklmnopqrstuvwxyz1234567890-=_+`~{}[]:;'\"\\|<>,./?!@#$%^&*()".ToCharArray();

            /// <summary>
            /// A textbox class that can accept input and displays it
            /// </summary>
            /// <param name="placeholder">The text that will show when no input has been entered</param>
            /// <param name="index">The unique index of the button</param>
            /// <param name="x">The x cordinate where the textbox will be displayed</param>
            /// <param name="y">The y cordiante </param>
            public Textbox(string placeholder, int index, int x, int y, bool hidden = false)
            {
                Placeholder = placeholder;
                Index = index;
                X = x;
                Y = y;   
                Hidden = hidden;
            }

            /// <summary>
            /// Adds a character to the input of the textbox
            /// </summary>
	    /// <param name="character">Here you pass the char that the user has entered while the textbox is selected</param>
            public virtual void AddLetter(char character)
            {
                if (allowed.Contains(character))
                {
                    Input += character;
                }
            }

            /// <summary>
            /// Removes a character from the input of the textbox
            /// </summary>
            public void Backspace()
            {
                if (Input != "")
                {
                    Input = Input.Remove(Input.Length - 1, 1);
                }
            }

            /// <summary>
            /// Displays the Textbox on the screen at the specified cordinates.
            /// </summary>
            /// <param name="current_index">The current index is the index that the user is currently on in the menu</param>
            public virtual void Display(int current_index)
            {
                Placeholder = Placeholder.PadRight(20);

                if (Input.PadRight(20) == "                    ")
                {
                    if (Index == current_index)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.BackgroundColor = ConsoleColor.Gray;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Console.SetCursorPosition(X, Y);
                    Console.WriteLine(Placeholder);


                }
                else
                {
                    if (Index == current_index)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    if (Hidden)
                    {
                        if (Input.Length < 20)
                        {
                            Console.SetCursorPosition(X, Y);
                            Console.WriteLine(new string('*', Input.Length).PadRight(20));
                        }
                        else
                        {
                            Console.SetCursorPosition(X, Y);
                            Console.WriteLine(new string('*', Input.Length).Remove(0, Input.Length - 20));
                        }
                    }
                    else
                    {
                        if (Input.Length < 20)
                        {
                            Console.SetCursorPosition(X, Y);
                            Console.WriteLine(Input.PadRight(20));
                        }
                        else
                        {
                            Console.SetCursorPosition(X, Y);
                            Console.WriteLine(Input.Remove(0, Input.Length - 20));
                        }
                    }
                }
                Console.ResetColor();
            }
        }
        
        
        public class ConditionalTextbox : Textbox
        {
            private int MinInputLength;
            private int MaxInputLength;

            /// <summary>
            /// The conditional textbox is a textbox that works the same as a normal textbox, but has some added tweaking features to it. You can
            /// for example set a maximun amount of characters the input can take. It's also possible to set a minimun amount of characters. If the length
            /// of the input is below the minimum, then the text in the Textbox will be red.
            /// </summary>
            /// <param name="placeholder">The text that is shown in the box when no input has been entered by the user</param>
            /// <param name="index">If the index is equal the the 'current index' in a menu, then it will light up, indicating that is is selected</param>
            /// <param name="x">The x position that the input box will be drawn at</param>
            /// <param name="y">The line (counted from upper to bottom) that the box will be drawn on</param>
            /// <param name="min">If the entered input's length is lowed than this int, the text in the box will be red</param>
            /// <param name="max">The max amount of characters the input will take</param>
            // /// <param name="hidden">If this is set to true, then the entered input will be hidden and replaced with '*' characters</param>
            public ConditionalTextbox(string placeholder, int index, int x, int y, int min = 0, int max = 100/*, bool hidden = false*/) : base(placeholder, index, x, y/*, hidden*/)
            {
                MinInputLength = min;
                MaxInputLength = max;
            }

	    /// <summary>
            /// Adds a character to the input of the textbox
            /// </summary>
	    /// <param name="character">Here you pass the char that the user has entered while the textbox is selected.
	    /// Unlike the Textbox class, this class only adds the character to the Input string variable if it will not exceed
	    /// the max MaxInputLength</param>
            public override void AddLetter(char character)
            {
                if (allowed.Contains(character) && Input.Length < MaxInputLength)
                {
                    Input += character;
                }
            }

	    /// <summary>
            /// Displays the Textbox on the screen at the specified cordinates.
            /// </summary>
            /// <param name="current_index">The current index is the index that the user is currently on in the menu</param>
            public override void Display(int current_index)
            {
                Placeholder = Placeholder.PadRight(20);

                if (Input.PadRight(20) == "                    ")
                {
                    if (Index == current_index)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.BackgroundColor = ConsoleColor.Gray;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Console.SetCursorPosition(X, Y);
                    Console.WriteLine(Placeholder);


                }
                else
                {
                    if (Index == current_index)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        if (Input.Length < MinInputLength)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        if (Input.Length < MinInputLength)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                    }

                    if (Input.Length < 20)
                    {
                        Console.SetCursorPosition(X, Y);
                        Console.WriteLine(Input.PadRight(20));
                    }
                     else
                    {
                        Console.SetCursorPosition(X, Y);
                        Console.WriteLine(Input.Remove(0, Input.Length - 20));
                    }
                }
                Console.ResetColor();
            }   
        }
    }

    public class Member
    {
	public string Firstname;
	public string Lastname;
	private string _Password;
	public int Creditcard;

	public Member()
	{
	    
	}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class EditMovie
    {
        private int Index;
        private List<api.Textbox> Textboxes = new List<api.Textbox>();
        private api.BigTextbox BigTextbox;
        private api.Button deleteButton;   
        private api.Button EditTime;
        public List<Movies> M;
        Movies movies = new Movies();

        public EditMovie()
        {

            Textboxes.Add(new api.Textbox("Title", 0, 0, 5, space_allowed:true));
            Textboxes.Add(new api.Textbox("Genre", 1, 0, 7, space_allowed: true));
            BigTextbox = new api.BigTextbox("Discription", 2, 0, 9, length : 3, width : 80, space_allowed: true);

            EditTime = new api.Button("Edit Time", 3, 0, 13);
            deleteButton = new api.Button("Delete Film", 4, 0, 20);

        }

        public void FirstRender()
        {
            api.PrintCenter("Edit Movie", 1);
            api.PrintCenter("When a box is left empty the specified item is kept the same", 2);
            string footer = "ARROW KEYS / TAB - Change box  |  ENTER - Finish  |  ESCAPE - Go back";
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
            BigTextbox.Display(Index);
            deleteButton.Display(Index);
            EditTime.Display(Index);    
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
                    if (Index < 4)
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
                    else
                    {
                        Index = Textboxes.Count + 2;
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
                if (Index == 2)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        BigTextbox.Backspace();
                    }
                    else
                    {
                        if (BigTextbox.Input.Length < 210)
                        {
                            BigTextbox.AddLetter(key.KeyChar);
                        }
                    }
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    if(Index == 3)
                    {
                        return 1;
                    }
                    if(Index == 4)
                    {
                        var deleteMovie = new MoviesList();
                        deleteMovie.Remove(Program.information.ChosenFilm.Name);
                        return 0;
                    }

                }

                DisplayTextboxes();
            }
            while (key.Key != ConsoleKey.Escape);
            return 0;
        }
    }
}

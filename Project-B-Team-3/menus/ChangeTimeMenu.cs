using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class ChangeTime
    {
        public int Index;
        public List<Movies> M;
        public List<List<api.Button>> Buttons = new List<List<api.Button>>();
        private List<api.Textbox> TextBox = new List<api.Textbox>();
        private MoviesList Movies;
        public ChangeTime()
        {
            Movies = new MoviesList();  
            Movies.Load();
            M = Movies.Movies;

            int p = 6;
            int tempindex = 0;
            int x = 0;
            //Creates all the buttons 
            for (int i = 0; i < Program.information.ChosenFilm.Dates.Count; i++)
            {
                TextBox.Add(new api.Textbox("Add/Delete time", tempindex, 2, p));
                tempindex++;    
                x = Console.WindowWidth / 2 - ((Program.information.ChosenFilm.Dates[i]["Time"].Count * 7) + (Program.information.ChosenFilm.Dates[i]["Time"].Count - 1) * 3) / 2 - 1;  // Finds middle of the screen for all boxes
                Buttons.Add(new List<api.Button>());
                for (int q = 0; q < Program.information.ChosenFilm.Dates[i]["Time"].Count; q++)
                {
                    Buttons[i].Add(new api.Button(Program.information.ChosenFilm.Dates[i]["Time"][q], tempindex, x, p));
                    x += 10;
                    tempindex++;
                }
                p += 3;
            }
            


        }
        private int DrawButtons()
        {
            int count = 0;
            for (int i = 0; i < Buttons.Count; i++)
            {
                for (int j = 0; j < Buttons[i].Count; j++)
                {
                    {
                        Buttons[i][j].Display(Index);
                        count++;

                    }
                }
                for (int p = 0; p < Buttons.Count; p++)
                {
                    TextBox[p].Display(Index);
                }



            }
                return count;
        }
        private void Firstrender()
        {
            api.PrintCenter("<<*Select the time on which you would like to see your movie*>>", 1);
            api.PrintCenter(Program.information.ChosenFilm.Name, 3, background: ConsoleColor.White, foreground: ConsoleColor.Black);
            api.PrintCenter("ARROW UP/DOWN - Select time| ENTER - Comfirm time | ESCAPE - Exit", 28);
            int j = 5;
            //Draws all the dates
            for (int i = 0; i < Program.information.ChosenFilm.Dates.Count; i++)
            {
                api.PrintCenter(Program.information.ChosenFilm.Dates[i]["Date"][0], j);
                j += 3;
            }
        }



        //Buttons is a jagged list of buttons, every list stands for a row of times on the screen.
        //The user uses the arrow keys to change the value of the index if the index is out of bound
        //it will go to the next list inside of buttons.
        public int Run()
        {
            Console.Clear();
            int normalIndex = 0;
            Index = (Buttons[0].Count - 1) / 2;
            var info = Program.information;
            Firstrender();
            int indexCount = DrawButtons();

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);


                if (TextBox[normalIndex].Index == Index)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        TextBox[normalIndex].Backspace();
                    }
                    else
                    {
                        TextBox[normalIndex].AddLetter(key.KeyChar);
                    }

                }

                if (key.Key == ConsoleKey.Enter)
                {

                    var Movies123 = new MoviesList();
                    Movies123.Load();
                    var M = Movies123.Movies;

                    if (TextBox[normalIndex].Index == Index)
                    {
                        string check = @"([0-1]?[0-9]|2[0-3]):[0-5][0-9]";
                        var regex = new System.Text.RegularExpressions.Regex(check);
                        int index = 0;
                        if (regex.IsMatch(TextBox[normalIndex].Input))
                        {
                            for (int i = 0; i < M.Count; i++)
                            {
                                if (M[i].Name == info.ChosenFilm.Name)
                                {
                                    index = i;
                                    break;
                                }
                            }

                            bool inTimeList = false;
                            for(int i = 0; i < M[index].Dates[normalIndex]["Time"].Count; i++)
                            {
                                
                                if (TextBox[normalIndex].Input == M[index].Dates[normalIndex]["Time"][i])
                                {
                                    inTimeList = true;
                                    Movies123.RemoveTime(index, normalIndex, TextBox[normalIndex].Input);
                                    break;
                                }
                            }
                            if (inTimeList == false && Buttons[normalIndex].Count < 7)
                            {
                                M[index].Dates[normalIndex]["Time"].Add(TextBox[normalIndex].Input);
                                Movies123.Save();
                            }

                            info.ChosenFilm = Movies123.Movies[index];
                            Program.information = info;

                            int p = 6;
                            int tempindex = 0;
                            int x = 0;

                            //We need to redraw the boxes and buttons, so we are able to show the added or romoved time.
                            Buttons = new List<List<api.Button>>();
                            TextBox = new List<api.Textbox>();
                            for (int i = 0; i < Program.information.ChosenFilm.Dates.Count; i++)
                            {
                                TextBox.Add(new api.Textbox("Add/Delete time", tempindex, 2, p));
                                Buttons.Add(new List<api.Button>());
                                tempindex++;
                                x = Console.WindowWidth / 2 - ((Program.information.ChosenFilm.Dates[i]["Time"].Count * 7) + (Program.information.ChosenFilm.Dates[i]["Time"].Count - 1) * 3) / 2 - 1;  // Finds middle of the screen for all boxes
                                api.PrintExact("                                                                                    ", x-15, p); //need to remove the previous time boxes before drawing the new ones.
                                for (int q = 0; q < Program.information.ChosenFilm.Dates[i]["Time"].Count; q++)
                                {
                                    Buttons[i].Add(new api.Button(Program.information.ChosenFilm.Dates[i]["Time"][q], tempindex, x, p));
                                    x += 10;
                                    tempindex++;
                                }
                                p += 3;
                            }
                        }
                        else if(Buttons[normalIndex].Count == 7)
                        {
                            api.PrintCenter("You are at your max of 7 dates!", 4, foreground: ConsoleColor.DarkRed);
                        }
                        else
                        {
                        api.PrintCenter("You did not type the time correct", 4, foreground: ConsoleColor.DarkRed);
                        }
                    }
                }
                    //When the index is smaller then the position of the last button, it will add one to the index.
                    if (key.Key == ConsoleKey.RightArrow && Index < Buttons[normalIndex][Buttons[normalIndex].Count - 1].Index)
                    {
                        Index++;
                    }
                    //When the index is greater then the position of the first button, it will add one to the index.
                    else if (key.Key == ConsoleKey.LeftArrow && Index > Buttons[normalIndex][0].Index - 1)
                    {
                        Index--;
                    }
                    //When key is down arrow it will move to the next box in the jagged list of boxes
                    else if (key.Key == ConsoleKey.DownArrow && normalIndex < Buttons.Count - 1)
                    {
                        //checks if next row is empty, if it is the row will be skipped.
                        if (Buttons[normalIndex + 1].Count > 0)
                        {
                            normalIndex++;
                            Index = Buttons[normalIndex][(Buttons[normalIndex].Count - 1) / 2].Index;
                        }
                        else if (normalIndex + 2 < Buttons.Count)
                        {
                            normalIndex += 2;
                            Index = Buttons[normalIndex][(Buttons[normalIndex].Count - 1) / 2].Index;


                        }
                    }
                    else if (key.Key == ConsoleKey.UpArrow && normalIndex > 0)
                    {
                        if (Buttons[normalIndex - 1].Count > 0)
                        {
                            normalIndex--;
                            Index = Buttons[normalIndex][(Buttons[normalIndex].Count - 1) / 2].Index;
                        }
                        else
                        {
                            normalIndex -= 2;
                            Index = Buttons[normalIndex][(Buttons[normalIndex].Count - 1) / 2].Index;

                        }
                    }

                    DrawButtons();
                }
                while (key.Key != ConsoleKey.Escape) ;
                return 0;
            }
        }
    }

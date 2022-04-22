using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class TimeSelection
    {
        public int Index;
        public List<Movies> M;
        public List<List<api.Button>> Buttons = new List<List<api.Button>>();

        public TimeSelection()
        {
            var Movies = new MoviesList();
            Movies.Load();
            M = Movies.Movies;

            int p = 6;
            int tempindex = 0;
            int x = 0;
            for (int i = 0; i < Program.information.ChosenFilm.Dates.Count; i++)
            {
                x = Console.WindowWidth/2-((Program.information.ChosenFilm.Dates[i]["Time"].Count*7)+(Program.information.ChosenFilm.Dates[i]["Time"].Count-1)*3)/2-1;
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
            for(int i = 0; i < Buttons.Count; i++)
            {
                for(int j = 0;j < Buttons[i].Count; j++)
                    {
                        Buttons[i][j].Display(Index);
                        count++;
                    }
            }
            return count;
        }
        private void Firstrender()
        {
            api.PrintCenter("<<*Select the time on which you would like to see your movie*>>", 1);
            api.PrintCenter("ARROW UP/DOWN - Select time| ENTER - Comfirm time | ESCAPE - Exit", 28);
            int j = 5;
            for (int i = 0; i < Program.information.ChosenFilm.Dates.Count; i++)
            {
                api.PrintCenter(Program.information.ChosenFilm.Dates[i]["Date"][0], j);
                j += 3;
            }
        }

        public int Run()
        {
            int normalIndex = 0;
            Index = (Buttons[0].Count-1)/2;
            Console.Clear();
            Firstrender();  
            int indexCount = DrawButtons();

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    var temporary = Program.information;

                    int count = 0;
                    string time = "";
                    for(int i = 0; i < Buttons.Count; i++) {
			for(int j = 0;j < Buttons[i].Count; j++) {
			    Console.WriteLine(count);
                            if (count == Index) {
                                time = Buttons[i][j].GetTitle();
				temporary.ChosenDate = Program.information.ChosenFilm.Dates[normalIndex]["Date"][0];
				temporary.ChosenTime = time;
				Program.information = temporary;
				return 1;
                            }
                            else
                            {
                                count++;
                            }
                        }
		    }
                }
                if (key.Key == ConsoleKey.RightArrow && Index < Buttons[normalIndex][Buttons[normalIndex].Count - 1].Index)
                {
                    Index++;
                }
                else if (key.Key == ConsoleKey.LeftArrow && Index > Buttons[normalIndex][0].Index)
                {
                    Index--;
                }
                else if (key.Key == ConsoleKey.DownArrow && normalIndex < Buttons.Count-1)
                {
                    if (Buttons[normalIndex+1].Count > 0)
                    {
                        normalIndex++;
                        Index = Buttons[normalIndex][(Buttons[normalIndex].Count - 1) / 2].Index;
                    }
                    else if(normalIndex+2 < Buttons.Count )
                    {
                        normalIndex+= 2;
                        Index = Buttons[normalIndex][(Buttons[normalIndex].Count - 1) / 2].Index;


                    }
                }
                else if (key.Key == ConsoleKey.UpArrow && normalIndex > 0)
                {
                    if (Buttons[normalIndex-1].Count > 0)
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
            while (key.Key != ConsoleKey.Escape);

            return 0;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class ReviewOverview
    {
        public int Index;
        public List<Review> R;

        public ReviewOverview()
        {
            var Reviews = new ReviewsList();
            R = Reviews._reviews;
        }

        private void DisplayMenu(int start, int end, int pagenumber)
        {
            Console.Clear();
            api.PrintCenter("<<*See all reviews*>>", 1);
            if (Program.information.Member == null || (Program.information.Member.Email != "admin" && Program.information.Member.Password != "admin"))
            {
                api.PrintCenter("ARROW UP/DOWN - Scroll reviews | ARROW LEFT/RIGHT - Select page | ESCAPE - Exit", 28);
            }
            else
            {
                api.PrintCenter("ARROW UP/DOWN - Scroll reviews | ARROW LEFT/RIGHT - Select page | ENTER - Delete review | ESCAPE - Exit", 28);
            }

            if (R.Count % 3 != 0)
            {
                api.PrintCenter("Page " + pagenumber + "/" + ((R.Count / 3) + 1), 2);
            }
            else if (R.Count <= 3 || R.Count % 3 == 0)
            {
                api.PrintCenter("Page " + pagenumber + "/" + (R.Count / 3), 2);

            }
            int j = 5;
            for (int i = start; i < end; i++)
            {
                Console.SetCursorPosition(0, j + 1);
                Console.WriteLine("Rating: " + R[i].Rating, j + 1);
                Console.SetCursorPosition(0, j + 2);
                Console.WriteLine("Review: ", j + 1);
                Console.SetCursorPosition(0, j + 3);
                Console.WriteLine(R[i].Text);

                j = j + 8;

            }

        }
        private void FirstRender(int start, int end, int pagenumber)
        {
            int j = 5;


            if (end > R.Count)

            {
                end = R.Count;
            }

            DisplayMenu(start, end, pagenumber);

            for (int i = start; i < end; i++)
            {
                if (i == Index)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.SetCursorPosition(0, j);
                    Console.WriteLine($"Name: {R[i].Name} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.SetCursorPosition(0, j);
                    Console.WriteLine($"Name: {R[i].Name} ");
                    Console.ResetColor();
                }

                j = j + 8;

            }
        }


        //uses pages and an index, when the index goes past 3 (3 because the max amount of movies on 1 page is 3) it swaps pages.
        public int Run()
        {
            var info = Program.information;

            int pagenumber = 1;
            int page = 0;
            int start = 0;
            int end = 3;
            int maxpage = R.Count % 3 == 0 ? R.Count / 3 : ((R.Count / 3) + 1);
            if (R.Count <= 3)
            {
                maxpage = 1;
            }

            if (end > R.Count)

            {
                end = R.Count;
            }

            Console.Clear();
            ConsoleKey keyPressed;
            FirstRender(start, end, pagenumber);
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                int p = 0;
                if (keyPressed == ConsoleKey.DownArrow && Index < end - 1)
                {
                    Index++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && Index > page)
                {
                    Index--;
                }
                //when the left arrow key is pressed it will swap te the previes page or when up arrow is pressed and the index is equal to the start variable.
                else if (keyPressed == ConsoleKey.LeftArrow && start > 0 || (keyPressed == ConsoleKey.UpArrow && Index == start && pagenumber > 1))
                {
                    Index = Index == start ? Index - 1 : start - 3;
                    start -= 3;
                    pagenumber--;
                    page = page - 3;

                    if (end % 3 == 0)
                    {
                        end = end - 3;
                    }
                    else
                    {
                        end = end - (end % 3);
                    }
                    Console.Clear();
                    FirstRender(start, end, pagenumber);
                    if (end > R.Count)

                    {
                        end = R.Count;
                    }
                }
                //when the right arrow key is pressed it will swap te the next page or when down arrow is pressed and the index is equal to the end variable.
                else if ((keyPressed == ConsoleKey.RightArrow && end < R.Count) || (keyPressed == ConsoleKey.DownArrow && Index == end - 1 && pagenumber < maxpage))
                {
                    page = page + 3;
                    pagenumber++;
                    Index = page;
                    start += 3;
                    end += 3;
                    Console.Clear();
                    FirstRender(start, end, pagenumber);
                    if (end > R.Count)

                    {
                        end = R.Count;
                    }
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    if (Program.information.Member != null && Program.information.Member.Email == "admin" && Program.information.Member.Password == "admin")
                    {
                        var deleteReview = new ReviewsList();
                        deleteReview.Remove(Index);
                        return 1;
                    }
                }

                int j = 5;
                //draws als de boxes again with the new given index.
                for (
                    int i = start; i < end; i++)
                {
                    if (i == Index)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.SetCursorPosition(0, j);
                        Console.WriteLine($"Name: {R[i].Name} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.SetCursorPosition(0, j);
                        Console.WriteLine($"Name: {R[i].Name} ");
                        Console.ResetColor();
                    }

                    j = j + 8;

                }
                Console.SetCursorPosition(0, p);
            } while (keyPressed != ConsoleKey.Escape);
            if (Program.information.Member == null || (Program.information.Member.Email != "admin" && Program.information.Member.Password != "admin"))
            {
                return 0;
            }
            return 1;
        }
    }
}
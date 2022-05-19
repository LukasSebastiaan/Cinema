using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class ReservationOverviewMenu
    {
        private int index;
        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> ReservationsDict;
        private List<Dictionary<string, string>> reservations;
        private List<string> IdList;
        public ReservationOverviewMenu()
        { 
            var info = Program.information;
            IdList = new List<string>();
            reservations = new List<Dictionary<string, string>>();
            int x = 0;
            var reservationHandler = new ReservationsHandler();
            foreach (var reservationId in reservationHandler.ResevationsDict[info.Member.Email].Keys)
            {
                reservations.Add(reservationHandler.ResevationsDict[info.Member.Email][reservationId]);
                IdList.Add(reservationId);
            }
        }

        public void Draw_Reservation()
        {
            string p = "";
            api.PrintCenter("Here is the overview of all your reservations", 2);
            api.PrintCenter($"{index + 1}/{reservations.Count}", 3);



            api.PrintCenter("Movie", 8, ConsoleColor.White, ConsoleColor.Black);
            api.PrintCenter(reservations[index]["MovieName"], 9);

            api.PrintCenter("Date and Time", 11, ConsoleColor.White, ConsoleColor.Black);
            api.PrintCenter(reservations[index]["Date"], 12);
            api.PrintCenter(reservations[index]["Time"], 13);

            api.PrintCenter("Seats", 15, ConsoleColor.White, ConsoleColor.Black);
            api.PrintCenter(reservations[index]["Seats"], 16);

            api.PrintCenter("Popcorn", 18, ConsoleColor.White, ConsoleColor.Black);
            api.PrintCenter(reservations[index]["PopcornAmount"], 19);
        }

        public void Firstrender()
        {
            Draw_Reservation();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            Console.Clear();
            Firstrender();
            int currentIndex = 0;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if(keyPressed == ConsoleKey.RightArrow && index < reservations.Count)
                {
                    index++;
                    Console.Clear();
                    Draw_Reservation();
                }
                else if(keyPressed == ConsoleKey.LeftArrow && index > 0)
                {
                    index--;
                    Console.Clear();
                    Draw_Reservation();
                }

            }
            while (keyPressed != ConsoleKey.Escape);
            return 0;
        }
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class ReservationOverviewMenu : IStructure
    {
        private int index;
        private int buttonindex;
        
        private List<Dictionary<string, string>> reservations;
        private List<string> IdList;

        private api.Button deletebutton;
        private api.Button backbutton;
        public ReservationOverviewMenu()
        { 
            var info = Program.information;

            IdList = new List<string>();
            reservations = new List<Dictionary<string, string>>();
            deletebutton = new api.Button("Delete", 0, (Console.WindowWidth - 8) / 2, 23);
            backbutton = new api.Button("Back", 1, (Console.WindowWidth - 6) / 2, 25);

            int x = 0;
            var reservationHandler = new ReservationsHandler();
            try
            {
                foreach (var reservationId in reservationHandler.ResevationsDict[info.Member.Email].Keys)
                {
                    reservations.Add(reservationHandler.ResevationsDict[info.Member.Email][reservationId]);
                    IdList.Add(reservationId);
                }
            }
            catch
            {

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

        public void FirstRender()
        {
            try
            {
                if (IdList.Count != 0)
                {
                    Draw_Reservation();

                    api.PrintCenter("ARROW UP/DOWN - Select buttons | ARROW LEFT/RIGHT - Select page | ENTER - Delete Reservation | ESCAPE - Exit", 28);

                    backbutton.Display(buttonindex);
                    deletebutton.Display(buttonindex);
                }
                else
                {
                    api.PrintCenter("You have not made a reservation yet!", 12);
                    api.PrintCenter("To make a reservation, start by choosing a movie at the movie menu", 13);
                    api.PrintCenter("We hope to have informed you sufficiently, see you soon!", 14);
                    api.PrintCenter("Press Escape to go back to the main menu...", 16);

                    api.PrintCenter("ARROW UP/DOWN - Select buttons | ARROW LEFT/RIGHT - Select page | ENTER - Delete Reservation | ESCAPE - Exit", 28);

                }
                
            }
            catch
            {
                api.PrintCenter("You have not made a reservation yet!", 12);
                api.PrintCenter("To make a reservation, start by choosing a movie at the movie menu", 13);
                api.PrintCenter("We hope to have informed you sufficiently, see you soon!", 14);
                api.PrintCenter("Press Escape to go back to the main menu...", 16);

                api.PrintCenter("ARROW UP/DOWN - Select buttons | ARROW LEFT/RIGHT - Select page | ENTER - Delete Reservation | ESCAPE - Exit", 28);
             
            }
        }


        public int Run()
        {
            ConsoleKey keyPressed;
            Console.Clear();
            Firstrender();
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if(keyPressed == ConsoleKey.RightArrow && index < reservations.Count-1)
                {
                    index++;
                    Console.Clear();
                    Firstrender();
                }
                else if(keyPressed == ConsoleKey.LeftArrow && index > 0)
                {
                    index--;
                    Console.Clear();
                    Firstrender();
                }
                else if(keyPressed == ConsoleKey.DownArrow && buttonindex < 1)
                {
                    buttonindex++;
                    Firstrender();
                }
                else if(keyPressed == ConsoleKey.UpArrow && buttonindex > 0)
                {
                    buttonindex--;
                    Firstrender();
                }
                else if(keyPressed == ConsoleKey.Enter && IdList.Count != 0)
                {
                    if(buttonindex == 1)
                    {
                        return -1;
                    }
                    else
                    {
                        ConfirmDecisionMenu confirmDecisionMenu = new ConfirmDecisionMenu();
                        int outcome = confirmDecisionMenu.Run();
                        Console.Clear();
                        if(outcome == 0)
                        {
                           Firstrender();
                        }
                        else
                        {
                            var reservationHandler = new ReservationsHandler();
                            var info = Program.information;

                            DateTime FilmDate = DateTime.ParseExact(reservations[index]["Date"], "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan FilmTime = TimeSpan.Parse(reservations[index]["Time"]);
                            DateTime CurrentDate = DateTime.Today;
                            TimeSpan CurrentTime = DateTime.Now.TimeOfDay;


                            if ((FilmDate - CurrentDate).TotalDays >= 7 && (FilmDate - CurrentDate).TotalDays >= 0)
                            {
                                if ((FilmDate - CurrentDate).TotalDays == 7)
                                {
                                    if (CurrentTime < FilmTime)
                                    {
                                        reservationHandler.RemoveReservation(info.Member.Email, IdList[index]);
                                        return -1;
                                    }

                                }
                                else
                                {
                                    reservationHandler.RemoveReservation(info.Member.Email, IdList[index]);
                                    return -1;
                                }
                            }

                            api.PrintCenter("You are to late, your reservation can not be canceled anymore.", 12);
                            api.PrintCenter("Reservations can be canceled at a maximum of 7 days before the start of the movie", 13);
                            api.PrintCenter("Press any key to continue...", 14);

                            keyInfo = Console.ReadKey(true);

                            Console.Clear();
                            Firstrender();

                        }
                    }
                }
            }
            while (keyPressed != ConsoleKey.Escape);
            return -1;
        }
    }
}


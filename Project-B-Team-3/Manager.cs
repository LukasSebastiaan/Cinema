using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ProjectB
{
    internal class Manager
    {
        public int MainMenu_LastIndex = 0;
        public void Start()
        {
            RunStartingMenu();
        }

        private void RunStartingMenu()
        {
            string prompt = @"
                                       __          __  _                          
                                       \ \        / / | |                         
                                        \ \  /\  / /__| | ___ ___  _ __ ___   ___ 
                                         \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \
                                          \  /\  /  __/ | (_| (_) | | | | | |  __/
                                           \/  \/ \___|_|\___\___/|_| |_| |_|\___|
                                            

";
            string[] options = { "Choose Film", "Login", "Register", "Reviews" };
            Welcome mainMenu = new Welcome(prompt, MainMenu_LastIndex);
            int selectedIndex = mainMenu.Run();

            MainMenu_LastIndex = selectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    MoviesMenu();
                    break;
                case 1:
                    LoginMenu();
                    break;
                case 2:
                    RegisterMenu();
                    break;
                case 3:
                    ReviewsMenu();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
		case 42069:
		    TestingMenu();
		    break;
            }
        }

        private void LoginMenu()
        {
            LoginMenu Login = new LoginMenu();
            int index = Login.Run();
            switch (index)
            {
                case 0:
                    RunStartingMenu();
                    break;
                case 1:
                    RunLoggedInMenu();
                    break;
                case 2:
                    RunAdminMenu();
                    break;
                    
            }
        }

        private void MoviesMenu()
        {
            MovieSelection Movie = new MovieSelection();
            int index = Movie.Run();
            switch (index)
            {
                case 0:
		    if (Program.information.Member == null)
		    {
			RunStartingMenu();
		    }
                    else
                    {
                        RunLoggedInMenu();
                    }
                    break;
                case 1:
                    TimeSelectionMenu();
                    break;

            }

        }
	
        private void TimeSelectionMenu()
        {
            TimeSelection Time = new TimeSelection();
            int index = Time.Run();
            switch (index)
            {
                case 0:
                    MoviesMenu();
                    break;
		        case 1:
                    SeatsChoosingMenu();
                    break;
            }

        }

        private void RegisterMenu()
        {
            Register register = new Register();
            int index  = register.Run();
            switch (index)
            {
                case 0:
                    RunStartingMenu();
                    break;
            }
        }

        private void ReviewsMenu()
        {
            Console.Clear();
            Console.WriteLine("Voer gebruikersnaam in:");
            string gebruikernaam = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Heeft u genoten van de film en onze service?\nWilt u een review achterlaten?:");
            string placereview = Console.ReadLine();
            string review = "";
            if (placereview == "ja")
            {
                Console.Clear();
                Console.WriteLine("Plaats hier uw mening over de bioscoop: ");
                review = Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Hopelijk heeft u genoten van uw bezoek bij de bioscoop\nTot de volgende keer!");
            }
            Console.Clear();
            if (placereview == "ja")
            {
                Console.WriteLine("Bedankt voor uw feedback.\nZie hieronder uw review over de bioscoop:\n\n" + gebruikernaam + "'s review: " + review);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Bedankt voor uw bezoek en tot de volgende keer!");
            }
        }

        private void SeatsChoosingMenu()
        {
            SeatsMenu seatsmenu = new SeatsMenu();
            int index = seatsmenu.Run();
            switch (index)
            {
		case 0:
                    TimeSelectionMenu();
                    break;
		case 1:
                    RunOverviewMenu();
                    break;
            }
        }

        private void RunOverviewMenu()
        { 
            OverviewMenu overviewmenu = new OverviewMenu();
            int index = overviewmenu.Run();
        }

        // This is a temporary testing screen that is accessed when F12 is pressed
        // while on the welcome menu screen. This will be deleted when 

	private void TestingMenu()
	{
            RunOverviewMenu();
        }
		
        private void RunLoggedInMenu()
        {
            LoggedInMenu loggedIn = new LoggedInMenu(); 
            int index = loggedIn.Run();
            switch (index) {
                case 0:
                    MoviesMenu();
                    break;
                case 1:

                    break;
                case 2:
                    break;
            }

        }
        private void RunAdminMenu()
        {
            AdminMenu adminMenu = new AdminMenu();
            int index = adminMenu.Run();
            switch (index) {
                case 0:
                    RunChooseFilmToEditMenu();
                    break;
            
            }

        }
        private void RunChooseFilmToEditMenu()
        {
            ChooseFilmToEditMenu ChooseFilmToEdit = new ChooseFilmToEditMenu();
            int index = ChooseFilmToEdit.Run();
            switch (index) 
            {
                case 0:
                    RunAdminMenu();
                    break;
                case 1:
                    RunEditMovieMenu();
                    break;
            }       


        }
        private void RunEditMovieMenu()
        {
            EditMovieMenu editMovieMenu = new EditMovieMenu();
            int index = editMovieMenu.Run();
            switch (index)
            {
                case 0:
                    RunChooseFilmToEditMenu();
                    break;

            }
        }
    }
}

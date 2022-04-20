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
            }
        }

        private void MoviesMenu()
        {
            MovieSelection Movie = new MovieSelection();
            int index = Movie.Run();
            switch (index)
            {
                case 0:
                    RunStartingMenu();
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
            }

        }




        private void RegisterMenu()
        {
            // 
        }

        private void ReviewsMenu()
        {
            //
        }

        private void TestingMenu()
	{
	    Testing testing = new Testing();
	    int index = testing.Run();
	}
		
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B_Team_3.menus
{
    class ReviewScreen
    {
        public void Start()
        {
            Console.WriteLine("Review Screen");
            RunReviewMenu();
            string strReview = "";

        //    Console.Clear();
        //    Console.WriteLine("Fill in username:");
        //    string gebruikernaam = Console.ReadLine();
        //    Console.Clear();
        //    Console.WriteLine("Heeft u genoten van de film en onze service?\nWilt u een review achterlaten?:");
        //    Console.WriteLine("Did you enjoy the movie and our service?\nDo you want to place a review?:");
        //    string placereview = Console.ReadLine();
        //    string review = "";
        //    if (placereview == "ja")
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Write your review here:");
        //        review = Console.ReadLine();
        //    }
        //    else
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Hopelijk heeft u genoten van uw bezoek bij de bioscoop\nTot de volgende keer!");
        //    }
        //    Console.Clear();
        //    if (placereview == "ja")
        //    {
        //        Console.WriteLine("Uw review is geplaatst.\nZie hieronder uw review over de bioscoop:\n\n" + gebruikernaam + "'s review: " + review + "\n\nBedankt voor uw feedback en tot de volgende keer!");
        //        Console.ReadLine();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Bedankt voor uw bezoek en tot de volgende keer!");
        //    }
        }

        private void RunReviewMenu()
        {
            string prompt = @"What would you like to do?
Please select and option.";
            string[] options = {" Place a review ", " See reviews "};
            ReviewMenu mainReviewMenu = new ReviewMenu(prompt, options);
            int selectedIndex = mainReviewMenu.ReviewRun();
            string StrReview = "";
            switch (selectedIndex)
            {
                case 0:
                    PlaceReview();
                    break;
                case 1:
                    SeeReview();
                    break;

            }
        }
        private void SeeReview()
        {
            // reviews laden uit een json en deze tonen
            Console.WriteLine("");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        private void ExitReview()
        {
            // ESC return to welcome screen
            Console.Clear();
        }

        private void PlaceReview()
        {
            string strReview = "";
            int counter = 0;
            Console.Clear();
            Console.WriteLine("Hopefully you enjoyed our service.\n\nWrite a review for our cinema:\n\n");
            strReview = Console.ReadLine();
            // herhaal loop als er geen text is en break als er text is
            while (counter == 0)
            {
                //Console.Clear();
                //Console.WriteLine("Write a review for our cinema:\n");
                //strReview = Console.ReadLine();
                //Console.Clear();
                if (string.IsNullOrEmpty(strReview))
                {
                    //Console.ReadLine();
                    Console.Clear();
                    //Console.WriteLine("Hopefully you enjoyed our service.\nWrite a review for our cinema: ");
                    Console.WriteLine("Something went wrong.\n\nPlease write a review for our cinema: \n");
                    strReview = Console.ReadLine();
                }
                else
                {
                    //Console.Clear();
                    //Console.WriteLine("Thank you for your feedback!");
                    ////strReview = Console.ReadLine();
                    counter++;
                }
            }
            //logboek 12 - 16 22/04/22
            Console.Clear();
            Console.WriteLine("Thank you for your feedback.\n\nSee your review here:\n\n" + strReview);
            Console.ReadKey(true);
            RunReviewMenu();
        }
    }
}

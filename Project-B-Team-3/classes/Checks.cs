using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectB
{
    // This class will be used to load and hold the list of accounts on the system
    static internal class Checks
    {
        /// <summary>
        /// This function runs all the checks that are made for the system. This includes thing like: Making sure there are
        /// no duplicate movies, dates, times, etc... 
        /// </summary>
        public static void CheckSystem()
        {
            var movies = new MoviesList();
            movies.Load();

            DuplicateMoviesCheck(movies);
            DuplicateDatesCheck(movies);
            DuplicateTimesCheck(movies);
        }

        private static void DuplicateMoviesCheck(MoviesList movies)
        {
            // Removing duplicate movies from the movies.json file.
            {
                var grouped_movies = movies.Movies.GroupBy(x => x.Name);
                foreach (var movie in grouped_movies)
                {
                    if (movie.Count() > 1)
                    {
                        for (int x = 0; x < movie.Count() - 1; x++)
                        {
                            movies.Remove(movie.Key);
                        }
                    }
                }
            }
        }

        private static void DuplicateDatesCheck(MoviesList movies)
        {
            // Removing duplicate times and dates for movies.
            foreach (var movie in movies.Movies)
            {
                var grouped_dates = movie.Dates.GroupBy(x => x["Date"][0]);
                int movieIndex = movies.Movies.IndexOf(movie);

                foreach (var date in grouped_dates)
                {
                    if (date.Count() > 1)
                    {
                        for (int x = 0; x < date.Count() - 1; x++)
                        {
                            foreach (var dateDict in movies.Movies[movieIndex].Dates)
                            {
                                if (dateDict["Date"][0] == date.Key)
                                {
                                    movies.RemoveDate(movieIndex, movies.Movies[movieIndex].Dates.IndexOf(dateDict), date.Key);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void DuplicateTimesCheck(MoviesList movies)
        {
            for (int movieIndex = 0; movieIndex < movies.Movies.Count; movieIndex++)
            {
                for (int dateIndex = 0; dateIndex < movies.Movies[movieIndex].Dates.Count; dateIndex++)
                {
                    var grouped_times = movies.Movies[movieIndex].Dates[dateIndex]["Time"].GroupBy(x => x);

                    foreach (var time in grouped_times)
                    {
                        if (time.Count() <= 1) { continue; }

                        for (int count = 0; count < time.Count() - 1; count++)
                        {
                            movies.RemoveTime(movieIndex, dateIndex, time.Key);
                        }
                    }
                }
            }
        }
        
        private static void DateFormatsCheck(MoviesList movies)
        {
            // Change all dd-M-yyyy to dd-MM-yyyy
        }

        private static void DateOverdueCheck(MoviesList movies)
        {
            // A check that will make all the passed dates for movies into comming dates.
        }
    }

}

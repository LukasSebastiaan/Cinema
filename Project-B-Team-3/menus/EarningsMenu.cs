using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class EarningsMenu
    {
	/* Initializing a new DateTime list that will hold the last 7 dates to pick
	the statistics from. */
        private List<DateTime> _lastDays = new List<DateTime>();
	private Dictionary<string, Dictionary<string, double>> _datesEarningsVisitors = new Dictionary<string, Dictionary<string, double>>();

        public EarningsMenu()
        {
            /* First figuring out what the date was 7 days ago. When that is found
	    we add it to the _lastDays list and do the same for the next 6 days. */
            DateTime initialDate = DateTime.Now.AddDays(-7);
            foreach (var _ in Enumerable.Range(0, 7))
	    {
                _lastDays.Add(initialDate);
                initialDate = initialDate.AddDays(1);
            }

	    /* Time to fill up the _datesEarningsVisitors dictionary with the last days
	    as strings, holding a the amount of money made that day and the amount of
	    visitors. */
	    foreach (DateTime date in _lastDays)
	    {
                string dateString = String.Format($"{date:dd-M-yyyy}");
                if (_datesEarningsVisitors.TryAdd(dateString, new Dictionary<string, double>()))
		{
                    _datesEarningsVisitors[dateString].Add("Earnings", 0.0);
                    _datesEarningsVisitors[dateString].Add("Visitors", 0.0);
                }
            }

            /* Now we can loop through all the reservations that have been made and check if the
            reservation's date is one of the dates in our last 7 days. If so, we add its amount
            of seats to the visitors count, and calculate the price based on the amount of popcorn
            and seats that have been reserved. Like this we only have to iterate over the reservations
	    once */
            var reservationHandler = new ReservationsHandler();
	    foreach (var member in reservationHandler.ResevationsDict.Keys)
	    {
		foreach (var reservationId in reservationHandler.ResevationsDict[member].Keys)
		{
                    Dictionary<string, string> reservation = reservationHandler.ResevationsDict[member][reservationId];
		    if (_datesEarningsVisitors.ContainsKey(reservation["Date"]))
		    {
                        string[] seats = reservation["Seats"].Split('|');
                        _datesEarningsVisitors[reservation["Date"]]["Visitors"] += seats.Length;
                        _datesEarningsVisitors[reservation["Date"]]["Earnings"] += (seats.Length * 12.50) + (Convert.ToInt32(reservation["PopcornAmount"]) * 5);
                    }
                }
            }
        }

        private void FirstRender()
        {
            // amount of visitors per day/week
            foreach (var date in _datesEarningsVisitors.Keys)
	    {
                Console.WriteLine($"{date}: {_datesEarningsVisitors[date]["Earnings"]}\t{_datesEarningsVisitors[date]["Visitors"]}");
            }
	    
	    // revenue per day/week

	    string footer = "ARROW KEYS - select options  |  ENTER - Confirm  |  ESCAPE - Exit";
            Console.SetCursorPosition((Console.WindowWidth - footer.Length) / 2, 28);
            Console.WriteLine(footer);
        }
	

        public int Run()
        {
            Console.Clear();
            FirstRender();
            ConsoleKey keyPressed;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

            } while (keyPressed != ConsoleKey.Escape);

            return -1;
        }

    }
}

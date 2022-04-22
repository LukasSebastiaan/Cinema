using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectB
{
    
    /// <summary>
    /// This class handles anything related to storing picked seats and accessing them
    /// </summary>
    internal class SeatsHandler
    {
        private Dictionary<string, Dictionary<string, Dictionary<string, int[][]>>> _seatsDict;
        private string SeatsJsonName = @$"Data{Path.DirectorySeparatorChar}Seats.json";

        public SeatsHandler()
        {
            if (File.Exists(SeatsJsonName))
            {
                if (new FileInfo(SeatsJsonName).Length != 0)
                {
                    Load();
                }
                else
                {
                    _seatsDict = new Dictionary<string, Dictionary<string, Dictionary<string, int[][]>>>();
                }
            }
            else
            {
                File.Create(SeatsJsonName);
                _seatsDict = new Dictionary<string, Dictionary<string, Dictionary<string, int[][]>>>();
            }
        }

        /// <summary>
        /// Adds seats to the taken seats array in the seats dictionary and instantly
        /// saves the seats into the json.
        /// </summary>
        /// <param name="moviename">The movie name that the seats are selected for</param>
        /// <param name="date">What date the seats are picked for</param>
        /// <param name="time">The time that the seats were picked for</param>
        /// <param name="chosen_seats">An array of int arrays that hold the row and seat of the chosen seats</param>
        public void Add(string moviename, string date, string time, int[][] chosen_seats)
        {
	    // Making a new array and then adding the newly picked seats together with
	    // already picked seats into the new array.
            int[][] currently_picked = _seatsDict[moviename][date][time];
            int[][] new_picked = new int[currently_picked.Length + chosen_seats.Length][];
            for (int p = 0; p < currently_picked.Length; p++){
                new_picked[p] = currently_picked[p];
            } for (int c = currently_picked.Length; c < currently_picked.Length + chosen_seats.Length; c++){
                new_picked[c] = chosen_seats[c];
            }

	    // Setting the new array as the array in the dictionary
	    // and saving it to the json
            _seatsDict[moviename][date][time] = new_picked;
            Save();
        }

	/// <summary>
	/// Removes given indexes from the picked seats in the json and in the seats dictionary
	/// </summary>
        /// <param name="moviename">The movie name that the seats are selected for</param>
        /// <param name="date">What date the seats are picked for</param>
        /// <param name="time">The time that the seats were picked for</param>
        /// <param name="chosen_seats">An array of int arrays that hold the row and seat of the seats that want to be removed</param>
        public void Remove(string moviename, string date, string time, int[][] removing_seats)
        {
	    // Turning the int[][] into a list and then using its Remove method to
	    // remove the given seats if they exist
            List<int[]> currently_picked = _seatsDict[moviename][date][time].ToList();
            foreach (int[] seat in removing_seats) {
		if (currently_picked.Contains(seat)) {
                    currently_picked.Remove(seat);
                }
            }

	    // Turning the new list into an int[][] array and setting it as the
	    // new picked seats. After that is instantly saved in the json
            _seatsDict[moviename][date][time] = currently_picked.ToArray();
            Save();
        }

	/// <summary>
	/// Returns the dictionary for READ PURPOSES ONLY. Only add and remove seats via
	/// the methods Remove, and Add!
	/// </summary>
        public Dictionary<string, Dictionary<string, Dictionary<string, int[][]>>> GetDict()
        {
            return _seatsDict;
        }

        /// <summary>
        /// Loads what is currently stored in the json file into the SeatsDict dictionary
        /// </summary>
        private void Load()
        {
            string json = File.ReadAllText(SeatsJsonName);
            _seatsDict = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, Dictionary<string, int[][]>>>>(json);
        }

	/// <summary>
	/// Saves any changes to the SeatsDict variable to the json file
	/// </summary>
        private void Save()
        {
            File.WriteAllText(SeatsJsonName, JsonSerializer.Serialize(_seatsDict));
        }
    }

}

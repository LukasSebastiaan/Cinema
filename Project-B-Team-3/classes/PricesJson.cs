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
    internal class PricesHandler
    {
        public class _PopcornPrices
        {
            private Dictionary<string, double> _popcornPrices;
            private Action Save;
            public _PopcornPrices(Dictionary<string, double> popcornprices, Action save)
            {
                _popcornPrices = popcornprices;
                Save = save;
            }

            public double this[string key]
            {
                get => _popcornPrices.ContainsKey(key) ? _popcornPrices[key] : throw new KeyNotFoundException("Couldn't find given key");
                set
                {
                    if (_popcornPrices.ContainsKey(key))
                    {
                        _popcornPrices[key] = value;
                    }
                    else
                    {
                        throw new KeyNotFoundException("You can only change an already existing key");
                    }
                }
            }

            public Dictionary<string, double> GetDict()
            {
                return _popcornPrices;
            }
        }

        public class _DrinksPrices
        {
            private Dictionary<string, double> _drinksPrices;
            private Action Save;
            public _DrinksPrices(Dictionary<string, double> popcornprices, Action save)
            {
                _drinksPrices = popcornprices;
                Save = save;
            }

            public double this[string key]
            {
                get => _drinksPrices.ContainsKey(key) ? _drinksPrices[key] : throw new KeyNotFoundException("Couldn't find given key");
                set
                {
                    if (_drinksPrices.ContainsKey(key))
                    {
                        _drinksPrices[key] = value;
                    }
                    else
                    {
                        throw new KeyNotFoundException("You can only change an already existing key");
                    }
                }
            }

            public Dictionary<string, double> GetDict()
            {
                return _drinksPrices;
            }
        }
        
        // 
	public struct Prices
	{
            public double MoviePrice { get; set; }
            public _PopcornPrices PopcornPrices { get; set; }
            public _DrinksPrices DrinksPrices { get; set; }
        }

        // This struct is only temporarly used to save the information to the json.
        private struct TemporaryPrices
        {
            public double MoviePrice { get; set; }
            public Dictionary<string, double> PopcornPrices { get; set; }
            public Dictionary<string, double> DrinksPrices { get; set; }
        }
        
	private static string PricesJsonName = @$"Data{Path.DirectorySeparatorChar}Prices.json";
        private Prices _prices;

        // MoviePrice property encapsulation for the Prices struct, changing the value will
        // update the json imidiately
        public double MoviePrice
        {
            get
            {
                return _prices.MoviePrice;
            }
            set
            {
                _prices.MoviePrice = value;
                Save();
            }
        }
        public _PopcornPrices PopcornPrices
        {
            get => _prices.PopcornPrices;
        }

        public _DrinksPrices DrinksPrices
        {
            get => _prices.DrinksPrices;
        }

        // Check if a prices json file exists, if the file exists it loads it into a Prices struct
        // and stores it in the _prices variable. If it can't find/can't load the json file, it creates
        // a new one with default values and loads that.
        public PricesHandler()
        {
            if (File.Exists(PricesJsonName))
            {
                try
                {
                    string json = File.ReadAllText(PricesJsonName);
                    var temp = JsonSerializer.Deserialize<TemporaryPrices>(json);
                    _prices = new Prices();
                    _prices.DrinksPrices = new _DrinksPrices(temp.DrinksPrices, Save);
                    _prices.PopcornPrices = new _PopcornPrices(temp.PopcornPrices, Save);
                    _prices.MoviePrice = temp.MoviePrice;
                }
                catch
                {
                    MakeDefault();
                }
            }
            else
            {
                MakeDefault();
            }            
        }

        private void MakeDefault()
        {
            Prices prices = new Prices();
            var DrinksPrices = new Dictionary<string, double>();
            var PopcornPrices = new Dictionary<string, double>();

            DrinksPrices.Add("Small", 2.50);
            DrinksPrices.Add("Medium", 3.00);
            DrinksPrices.Add("Large", 3.50);
                
            PopcornPrices.Add("Small", 2.50);
            PopcornPrices.Add("Medium", 3.00);
            PopcornPrices.Add("Large", 3.50);

            prices.PopcornPrices = new _PopcornPrices(PopcornPrices, Save);
            prices.DrinksPrices = new _DrinksPrices(DrinksPrices, Save);

            _prices = prices;

            Save();
        }
        
        private void Save()
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;

            var temp = new TemporaryPrices();
            temp.DrinksPrices = _prices.DrinksPrices.GetDict();
            temp.PopcornPrices = _prices.PopcornPrices.GetDict();

            File.WriteAllText(PricesJsonName, JsonSerializer.Serialize(temp, options: options));
        }
    }
}

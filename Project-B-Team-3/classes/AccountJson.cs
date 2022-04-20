using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectB
{
    // An account that is initialized for every member that has an account on the
    // system.
    public class Account
    {
        [JsonPropertyName("Firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("Lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("Creditcard")]
        public string Creditcard { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

	[JsonPropertyName("Password")]
	public string Password { get; set; }
    }

    // This class will be used to load and hold the list of accounts on the system
    internal class AccountList
    {
        public List<Account> Accounts;
        public const string AccountJsonName = "Accounts.json";

	// Loads all the existing accounts in the Accounts.json into the accounts list
        public void Load()
        {
            string json = File.ReadAllText(AccountJsonName);

            Accounts = JsonSerializer.Deserialize<List<Account>>(json);

            Console.WriteLine("test: " + Accounts[0].Firstname);
        }

        public void Save()
        {
            File.WriteAllText(AccountJsonName, JsonSerializer.Serialize(Accounts));
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using ProjectB;

namespace ProjectB
{
    internal class Testing
    {
        public int Run()
        {
            Console.Clear();
            AccountList AL = new AccountList();
            AL.Load();
            Console.WriteLine(AL.Accounts[2].Firstname);

            return 1;
        }
    }
}

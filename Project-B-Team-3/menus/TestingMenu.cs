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
        private int Index = 0;
       
	
        public int Run()
        {

            
            ConsoleKey keyPressed;
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                keyPressed = key.Key;
		
                if (keyPressed != ConsoleKey.Backspace)
                {
                    
                }
                else
                {
                    
                }

            } while (keyPressed != ConsoleKey.Escape);
            return 0;
        }
    }
}

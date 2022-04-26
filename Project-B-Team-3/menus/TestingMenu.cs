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
	
        private api.BigTextbox bigtextbox = new api.BigTextbox("Input anything you want", 0, 3, 5, true, 80, 4);
	
        public int Run()
        {
            bigtextbox.Display(Index);
            ConsoleKey keyPressed;
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                keyPressed = key.Key;
		
		if (keyPressed != ConsoleKey.Backspace)
		{
                    bigtextbox.AddLetter(key.KeyChar);
                }
		else
		{
                    bigtextbox.Backspace();
                }

                bigtextbox.Display(Index);

            } while (keyPressed != ConsoleKey.Escape);
            return 0;
        }
    }
}

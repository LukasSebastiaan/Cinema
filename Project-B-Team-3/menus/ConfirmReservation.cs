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
    internal class ConfirmReservation
    {
        public void FirstRender()
        {
            api.PrintCenter(Program.information.Member.Firstname + " " + Program.information.Member.Lastname + ", thank you for your reservation!", 13);
            api.PrintCenter("An comfirmation email has been sent.", 14);
            api.PrintCenter("Enjoy!", 15);
            api.PrintCenter("press Enter to confirm...", 17);
        }

        public int Run()
        {
            Console.Clear();
            ConsoleKey keyPressed;
            FirstRender();
            do
            {
                var info = Program.information;
                ConsoleKeyInfo key = Console.ReadKey(true);
                keyPressed = key.Key;

                if (keyPressed == ConsoleKey.Enter)
                {
                    var Dict = new Dictionary<string, string>() { { "{{Username}}", info.Member.Email }, { "{{MovieDate}}", info.ChosenDate }, { "{{MovieTime}}", info.ChosenTime }, { "{{MovieTitle}}", info.ChosenFilm.Name }, { "{{Seats}}", info.ChosenSeats.ToString() }, { "{{PopcornAmount}}", info.PopcornAmount.ToString() } }; // Defined vars to be replaced in mail template
                    SendEmail.SendVerifyEmail(Program.information.Member.Email, "htmlReservation.txt", Dict); // Sends the email

                    return 0;
                }

            } while (keyPressed != ConsoleKey.Escape);
            return 0;
        }
    }
}

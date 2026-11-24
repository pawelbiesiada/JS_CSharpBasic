using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    internal class BirthdayCalculator
    {
        public void Run()
        {
            //read 1 values from console
            Console.Write("Type your birthday (yyyy-MM-dd): ");  // 11/03/2026
            var input1 = Console.ReadLine();
            // parse them to DateTime
            bool isParse = DateTime.TryParseExact(input1, "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime birthday);
            var counter = 0;
            while (!isParse)
            {
                if (counter > 5)
                {
                    Console.WriteLine("Too many invalid inputs. Exiting.");
                    return;
                }
                Console.WriteLine("Invalid input");
                Console.Write("Type your birthday again (yyyy-MM-dd): ");
                input1 = Console.ReadLine();
                isParse = DateTime.TryParseExact(input1, "yyyy-MM-dd", null, DateTimeStyles.None, out birthday);
                counter++;
            }
            //calculate age
            int ageInDays = CalculateAgeInDays(birthday);
            int ageInYears = CalculateAgeInYears(birthday);
            //print result to console
            Console.WriteLine($"You are {ageInYears} years old and {ageInDays} days old.");
        }

        private int CalculateAgeInYears(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;
            return age;
        }

        private int CalculateAgeInDays(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today - birthday;
            return age.Days;
        }
    }
}

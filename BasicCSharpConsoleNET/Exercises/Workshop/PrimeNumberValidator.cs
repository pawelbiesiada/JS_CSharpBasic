using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    internal class PrimeNumberValidator
    {
        public void Run()
        {
            //read 1 values from console
            Console.Write("Type a number: ");
            var input1 = Console.ReadLine();

            // parse them to int
            //int a = int.Parse(input1);
            bool isParse = int.TryParse(input1, out int a);

            var counter = 0;
            while (!isParse)
            {
                if (counter > 5)
                {
                    Console.WriteLine("Too many invalid inputs. Exiting.");
                    return;
                }

                Console.WriteLine("Invalid input");
                Console.Write("Type a number again: ");
                input1 = Console.ReadLine();
                isParse = int.TryParse(input1, out a);
                counter++;
            }


            //validate triangle
            bool isValid = IsPrime(a);
            //print result to console
            if (isValid)
            {
                Console.WriteLine("Is a prime number");
            }
            else
            {
                Console.WriteLine("Is not a prime number");
            }
        }

        public bool IsPrime(int number)
        {
            //for(int i = 2; i < number; i++)
            //{
            //    if(number % i == 0)
            //    {
            //        return false;
            //    }
            //}

            var i = 2;
            while (i < number)
            {
                if (number % i == 0)
                {
                    return false;
                }
                i++;
            }

            return true;
        }
    }
}

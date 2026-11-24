using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    public class TriangleValidator
    {
        public void Run()
        {
            //read 3 values from console
            Console.Write("Enter the lengths of the side of the triangle: ");
            var input1 = Console.ReadLine();
            Console.Write("Enter the lengths of the side of the triangle: ");
            var input2 = Console.ReadLine();
            Console.Write("Enter the lengths of the side of the triangle: ");
            var input3 = Console.ReadLine();
            // parse them to int
            int a = int.Parse(input1);
            var b = int.Parse(input2);
            var c = int.Parse(input3);
            //validate triangle
            bool isValid = IsValidTriangle(a, b, c);
            //print result to console
            if (isValid)
            {
                Console.WriteLine("Valid triangle");
            }
            else
            {
                Console.WriteLine("Invalid triangle");
            }
        }

        private bool IsValidTriangle(int a, int b, int c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }
    }
}

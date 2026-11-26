using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    internal class Ex1
    {
        public void PrintHi(string name)
        {
            if (name == null)
                name = string.Empty;

            Console.WriteLine($"Hallo {name}!");

            var mc = new MyClass();
        }
    }


    class MyClass
    {
        // constructor
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    internal class Robot
    {
        //właściwości
        public string Name{ get; set; }
        public ushort Age { get; set; }
        public bool IsOn { get; set; }

        //konstruktor
        public Robot(string name,  ushort age) : this()
        {
            Name = name;
            Age = age;
        }

        public Robot()
        {
            IsOn = true;
        }

        //metody
        public void SayHi()
        {
            if(IsOn)
            {
                Console.WriteLine($"Say Hi {Name}");
            }

            // var robot = new Robot("Robert", 20);
        }
    }
}

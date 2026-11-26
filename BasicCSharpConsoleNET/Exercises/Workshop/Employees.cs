using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    internal abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual void CalculateSalary()
        {
            Console.Write($"Obliczam wyplate dla {GetType().Name}: {Name} ");
        }

        public override string ToString()
        {
            return $"My name is {Name}, Id: {Id}";
        }

        public override bool Equals(object obj)
        {
            if(obj is Employee)
            {
                var emp = (Employee)obj;

                return Id == emp.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }

    class Secretary : Employee
    {
        public override void CalculateSalary()
        {
            base.CalculateSalary();
            Console.WriteLine("Kwota 6000");
        }
    }

    class Director : Employee
    {
        public void GetBonus()
        {
            Console.WriteLine("Bonus dla dyrektora: " + Name);
        }
        public override void CalculateSalary()
        {
            base.CalculateSalary();
            Console.WriteLine("Kwota 8000");
        }
    }

    class Programmer : Employee
    {
        public override void CalculateSalary()
        {
            base.CalculateSalary();
            Console.WriteLine("Kwota 7000");
        }
    }


    class TestEmployee
    {
        public void Run()
        {
            var s1 = new Secretary() { Id = 1, Name = "John" };
            var s2 = new Secretary() { Id = 2, Name = "Dave" };
            var d1 = new Director() { Id = 3, Name = "Alan" };
            var p1 = new Programmer() { Id = 4, Name = "Alice" };
            var p2 = new Programmer() { Id = 5, Name = "Bob" };

            var emp = new Employee[] { s1, s2, d1, p1, p2 };
            Print(emp);

            var p3 = new Programmer() { Id = 4, Name = "Anna" };

            var areEqual = p1.Equals(p2);
        }

        public void Print(Employee[] employees)
        {
            foreach (var employee in employees) 
            {
                employee.CalculateSalary();

                if (employee is Director)  // is lub as
                {
                    var dir = (Director)employee;
                    dir.GetBonus();
                    //((Director)employee).GetBonus();
                }
            }
        }
    }
}

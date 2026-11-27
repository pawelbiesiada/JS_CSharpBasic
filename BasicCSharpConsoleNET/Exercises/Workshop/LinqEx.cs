using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    internal class LinqEx
    {
        public void Run()
        {
            var users = CreateCollection.GetUsers();


            //Dictionary<string, List<Task<User>>> list = null; 
            // John -> 1:John, 10:John
            // Bob -> 2:Bob, 

            //Any
            var hasAnyElement = users.Any();

            //non-null elements
            users = users.Where(u => u != null);
            var nonNullUsers = users.Count();

            //M-users
            users
                .Where(u => u.Name.StartsWith("M", StringComparison.CurrentCultureIgnoreCase))
                .ToList()
                .ForEach(Console.WriteLine);



            //Action<User>  ->      void Mth(User u)
            //Func<bool, User>  ->  bool Mth(User u)

            //top 5 ordered
            var fiveUsers = users
                .Take(5)
                .OrderBy(userElement => userElement.Name);
            
            //var names = from u in users where u.Name.StartsWith("M") select u.Id;

            //get all distinct names 
            var names = users
                .Select(x => x.Name)
                .Distinct();

            //duplicated names
            var dupNames = users
                .GroupBy(u => u.Name)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key);

            //only SuperUsers
            var superUser = users.OfType<SuperUser>();

            //Only active admins
            var activeAdmins = users
                .OfType<SuperUser>()
                .Where(x => x.IsActive && x.IsAdmin);

            //only one admin user
            var admin = users
                .OfType<SuperUser>()
                .FirstOrDefault(x => x.IsAdmin);
                //.First(x => x.IsAdmin);
            if(admin != null)
            {
                Console.WriteLine( admin.Name);
            }

            //Dictionary with number of users with the same name
            var dict = users
                .GroupBy(u => u.Name)
                .ToDictionary(g => g.Key, g => g.Count());


            //Collections  -> IEnumerable
                //Arrays
                //List<>
                //Dictionary<int, string>, HashSet<int>
                //Stack<> -> LIFO
                //Queue<> -> FIFO

            var johns = dict["John"];   //dict.ContainsKey("John")
        }
    }
}

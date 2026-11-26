using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    internal class LinqEx
    {
        public void Run()
        {
            var users = CreateCollection.GetUsers();

            //Any
            var hasAnyElement = users.Any();

            //non-null elements
            users = users.Where(u => u != null);
            var nonNullUsers = users.Count();

            //M-users
            var mUsers = users
                .Where(u => u.Name.StartsWith("M", StringComparison.CurrentCultureIgnoreCase));
            foreach (var user in mUsers)
            {
                Console.WriteLine(user.Name);
            }

            //top 5 ordered
            var fiveUsers = users
                .Take(5)
                .OrderBy(userElement => userElement.Name);

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


            //Collections
                //Arrays
                //List
                //Dictionary, HashSet
                //Stack
                //Queue

            var johns = dict["John"];   //dict.ContainsKey("John")
        }
    }
}

using BasicCSharpConsoleNET.Samples.SQL;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using Persistence.Interfaces;
using Persistence.Models;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    internal class PrintGroups
    {
        IUsersRepository _repository;

        public PrintGroups(IUsersRepository repository)
        {
            _repository = repository;
        }

        public void Run()
        {
            //print all available group names to a console

            var connStr = new ConnectionStringProvider().GetConnectionSting();

            using (var connection = new SqlConnection(connStr))  // IDisposable
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT Name FROM  Groups";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nameCol = (string)reader["Name"];
                    Console.WriteLine($"{nameCol}");
                }
            } // Dispose()          - >  SqlConnection - closes connection
        }
        public void Run(string name)
        {
            //print all available group names to a console

            var connStr = new ConnectionStringProvider().GetConnectionSting();

            using (var connection = new OracleConnection(connStr))  // IDisposable
            {
                connection.Open();

                var command = connection.CreateCommand();

                var p1 = command.CreateParameter();
                p1.ParameterName = "p1";
                p1.Value = name;
                p1.DbType = System.Data.DbType.String;

                command.CommandText = $"SELECT Name FROM  Groups WHERE Name = @p1";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nameCol = (string)reader["Name"];
                    Console.WriteLine($"{nameCol}");
                }
            } // Dispose()          - >  SqlConnection - closes connection
        }

        public void CallRepository()
        {
            foreach (var user in _repository.GetActiveUsers())
            {
                Console.WriteLine(user.Name);
            }

            var userWithJ = _repository.GetUsers().Where(u => u.Name.StartsWith("J"));
        }
    }




    class RepoMock : IUsersRepository
    {
        public void AddUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetActiveUsers()
        {
            return new List<UserDto>
            {
                new UserDto{Id = 1, Name = "John" }
            };
        }

        public IEnumerable<GroupDto> GetGroups()
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserGroupsDto> GetUserGroups()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return new List<UserDto>
            {
                new UserDto{Id = 1, Name = "John" },
                new UserDto{Id = 2, Name = "Mark" }
            };
        }

        public void RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

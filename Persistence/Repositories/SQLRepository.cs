using Persistence.Interfaces;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Persistence.Repositories
{
    public class SQLRepository : IUsersRepository
    {
        string _connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFTestDb;Integrated Security=True;";
        
        
        public void AddUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetActiveUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupDto> GetGroups()
        {
            var groups = new List<GroupDto>();
            using (var connection = new SqlConnection(_connStr))  // IDisposable
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name FROM  Groups";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    groups.Add(new GroupDto
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }

            return groups;
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
            var users = new List<UserDto>();
            using (var connection = new SqlConnection(_connStr))  // IDisposable
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Password, IsActive FROM  Users";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new UserDto
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Password = reader.GetString(2),
                        IsActive = reader.GetBoolean(3)
                    });
                }
            }

            return users;
        }

        public void RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

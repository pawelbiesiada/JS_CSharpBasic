using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<UserDto> GetUsers();
        Task<IEnumerable<UserDto>> GetUsersAsync();
        IEnumerable<UserDto> GetActiveUsers();

        void AddUser(UserDto user);

        void RemoveUser(int userId);

        UserDto GetUser(int id);

        IEnumerable<GroupDto> GetGroups();

        IEnumerable<UserGroupsDto> GetUserGroups();
    }
}

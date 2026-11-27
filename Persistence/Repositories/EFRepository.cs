using NLog;
using Persistence.DbModels;
using Persistence.Interfaces;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class EFRepository : IUsersRepository
    {
        private EftestDbContext _ctx = new EftestDbContext();
        private ILogger _logger = LogManager.GetCurrentClassLogger();

        public void AddUser(UserDto user)
        {
            _logger.Info("I'm about to add new user");
            _ctx.Users.Add(new User
            {
                Name = user.Name,
                IsActive = user.IsActive,
                Password = user.Password,
            });

            _ctx.SaveChanges();
            _logger.Info("User added");
        }

        public IEnumerable<UserDto> GetActiveUsers()
        {
            return _ctx.Users
                .Where(u => u.IsActive)
                .Select(CastUser);
        }

        public IEnumerable<GroupDto> GetGroups()
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(int id)
        {
            return _ctx.Users
                .Where(u => u.Id == id)
                .Select(CastUser)
                .Single();
        }

        public IEnumerable<UserGroupsDto> GetUserGroups()
        {
            var usersWithGroups = _ctx.Users
                .Select(u => new UserGroupsDto
                {
                    User = CastUser(u),
                    Groups = u.UserGroups.Select(ug => CastGroup(ug.Group))
                });
            return usersWithGroups;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int userId)
        {
            var user = _ctx.Users
                .First(u => u.Id == userId);
            _ctx.Users.Remove(user);

            _ctx.SaveChanges();
        }


        private UserDto CastUser(User u)
        {
            return new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                IsActive = u.IsActive,
                Password = u.Password
            };
        }

        private GroupDto CastGroup(Group u)
        {
            return new GroupDto
            {
                Id = u.Id,
                Name = u.Name,
            };
        }
    }
}

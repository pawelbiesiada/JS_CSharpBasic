using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Models
{
    public class UserGroupsDto
    {
        public UserDto User { get; set; }
        public IEnumerable<GroupDto> Groups { get; set; }
    }
}

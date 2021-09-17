using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.DTOs
{
   public class UserSearchDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public List<UserDto> Users { get; set; }
    }
}

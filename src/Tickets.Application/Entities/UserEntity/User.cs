
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Entities.UserEntity
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string ProfileImage { get; set; }
    }
}

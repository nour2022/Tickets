using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Entities
{
    class User:FullAuditedEntityBase<int>
    {
        public int? ClientId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Info { get; set; }
    }
}

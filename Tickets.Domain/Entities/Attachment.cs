using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain;

namespace Tickets.Domain.Entities
{
    public class Attachment : FullAuditedEntityBase<int>
    {

        public string Name { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public string Extention { get; set; }

    }
}

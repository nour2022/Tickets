﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Entities
{
    class Client:FullAuditedEntityBase<int>
    {
        public string FullName { get; set; }
      
    }
}

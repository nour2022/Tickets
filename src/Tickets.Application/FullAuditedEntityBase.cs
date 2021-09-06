using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application
{
   
    [Serializable]
    public abstract class EntityBase 
    {

    }

    [Serializable]
    public abstract class EntityBase<TKey> : EntityBase
    {
        public TKey Id { get; set; }
    }

    public class FullAuditedEntityBase<TKey>:EntityBase
    {
        public TKey Id { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}

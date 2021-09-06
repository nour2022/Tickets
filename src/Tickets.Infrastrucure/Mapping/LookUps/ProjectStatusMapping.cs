using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Lookups.Entities;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Mapping.LookUps
{
    class ProjetStatusMapping : EntityTypeConfiguration<ProjectStatus>
    {
     
        public override void Configure(EntityTypeBuilder<ProjectStatus> entity)
        {
            entity.ToTable("ProjetStatus", "lookups");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(256);
        }
    }
}

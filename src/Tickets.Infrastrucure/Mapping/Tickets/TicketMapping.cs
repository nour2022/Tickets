using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Tickets.Entities;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Mapping.Tickets
{
    class TicketMapping : EntityTypeConfiguration<Ticket>
    {
        public override void Configure(EntityTypeBuilder<Ticket> entity)
        {
            entity.ToTable("Ticket", "tickets");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PriorityId).IsRequired();
            entity.Property(e => e.StateId).IsRequired();
            entity.Property(e => e.TickeTypeId).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.ProjectId).IsRequired();
          
            entity.Property(e => e.CreatedBy).IsRequired();
            entity.Property(e => e.CreatedOn).IsRequired();


           
            entity.HasOne(e => e.Priority).WithMany(e => e.Tickets).HasForeignKey(e => e.PriorityId);
            entity.HasOne(e => e.Type).WithMany(e => e.Tickets).HasForeignKey(e => e.TickeTypeId);
             entity.HasOne(e => e.State).WithMany(e => e.Tickets).HasForeignKey(e => e.StateId);
            entity.HasOne(e => e.Project).WithMany(e => e.Tickets).HasForeignKey(e => e.ProjectId);

        }
    }
}

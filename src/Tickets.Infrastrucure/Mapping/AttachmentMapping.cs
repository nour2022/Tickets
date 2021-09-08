using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Entities;

namespace Tickets.Infrastrucure.Mapping
{
    class AttachmentMapping : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> entity)
        {
            entity.ToTable("Attachment", "Attachments");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Path).IsRequired();
            entity.Property(e => e.Type).IsRequired();

        }
    }
}

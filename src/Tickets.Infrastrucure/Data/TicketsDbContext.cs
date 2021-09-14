
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Tickets.Domain.Entities;
using Tickets.Domain.Entities.UserEntity;
using Tickets.Domain.Lookups.Entities;
using Tickets.Domain.Projects.Entities;
using Tickets.Domain.Tickets.Entities;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Data
{
    public class TicketsDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Project> Projects  { get; set; }
        public DbSet<ProjectTeam> ProjectTeams { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<TicketAttachment> TicketAttachments { get; set; }
        public DbSet<ProjectStatus> projectStatus{ get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<TicketState> TicketStates { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options)
        {
           
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                && (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}

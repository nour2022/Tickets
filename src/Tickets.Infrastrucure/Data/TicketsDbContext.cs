using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Tickets.Application.Tickets.Entities;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Data
{
    public class TicketsDbContext: IdentityDbContext
    {
        public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Debugger.Launch();

            //dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                && (type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}

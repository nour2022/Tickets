using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tickets.Application.Services;
using Tickets.Domain.Entities.UserEntity;
using Tickets.Infrastrucure.Data;

namespace Tickets.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TicketsDbContext>(options=> options.UseSqlServer(Configuration.GetConnectionString("Tickets")));

            services.AddScoped<ProjectAppService>();
            services.AddScoped<TicketAppService>();
            services.AddScoped<TicketAttachmentAppService>();
            services.AddScoped<UserAppService>();
            services.AddScoped<RoleAppService>();
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<TicketsDbContext>();
            services.AddRazorPages();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAccess", p => p.RequireRole("Admin"));

                options.AddPolicy("ManagerAccess",
                    p => p.RequireAssertion(c =>
                       c.User.IsInRole("Admin") 
                    || c.User.IsInRole("Manager")));
                options.AddPolicy("TeamAccess",
                   p => p.RequireAssertion(c =>
                      c.User.IsInRole("Admin")
                   || c.User.IsInRole("Manager")
                   || c.User.IsInRole("Development Team")
                    ));
                options.AddPolicy("UserAccess",
                    p => p.RequireAssertion(c => 
                       c.User.IsInRole("Admin") 
                    || c.User.IsInRole("Manager")
                   
                    || c.User.IsInRole("User")));

                options.AddPolicy("TeamUserAccess",
                  p => p.RequireAssertion(c =>
                     c.User.IsInRole("Admin")
                  || c.User.IsInRole("Manager")
                  || c.User.IsInRole("Developer Team")
                  || c.User.IsInRole("User")));

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

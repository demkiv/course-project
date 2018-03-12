using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Concrete;
using DeanerySystem.DataAccess.Entities.Identity;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DeanerySystem.WebUI.Services;

namespace DeanerySystem.WebUI
{
    public class Startup
    {
        private const bool UseSqlDb = true;  
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (UseSqlDb)
            {
                services.AddDbContext<DeaneryDbContext>(options =>
                    options./*UseLazyLoadingProxies()
                        .*/UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
            }
            else
            {
                services.AddDbContext<DeaneryDbContext>(options =>
                    options.UseInMemoryDatabase("DeaneryDatabase"));
            }

            services.AddIdentity<DeaneryUser, DeaneryRole>()
                .AddEntityFrameworkStores<DeaneryDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //using (var serviceScope =
                //    app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                //{
                //    if (UseSqlDb && !serviceScope.ServiceProvider.GetService<DeaneryDbContext>().AllMigrationsApplied())
                //    {
                //        serviceScope.ServiceProvider.GetService<DeaneryDbContext>().Database.Migrate();
                //    }
                //    serviceScope.ServiceProvider.GetService<DeaneryDbContext>().EnsureSeeded();   
                //}
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

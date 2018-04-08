using System;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using DomainServices.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddResponseCaching();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(this.configuration.GetConnectionString("Blog")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = this.configuration["GoogleApi:ClientId"];
                options.ClientSecret = this.configuration["GoogleApi:ClientSecret"];
            });

            services.AddAutoMapper();
            services.AddMvc();

            return ConfigureIoC(services);
        }

        private IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.AssemblyContainingType(typeof(Startup));
                    scan.AssemblyContainingType(typeof(PostService));
                    scan.AssemblyContainingType(typeof(Post)); 
                    scan.Assembly("Infrastructure"); 
                    scan.WithDefaultConventions();
                });

                config.For(typeof(IRepository<>)).Add(typeof(Repository<>));
                
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseResponseCaching();
            app.UseStaticFiles();
            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());

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

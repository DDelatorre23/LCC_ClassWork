﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using CommunityWebSite.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using CommunityWebSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CommunityWebSite {

    public class Startup {

        IConfiguration Configuration;

        public Startup(IHostingEnvironment env) {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .Build();
        }
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration["Data:CommunityMessages:DefaultConnection"]));

            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
                Configuration["Data:CommunityMessagesIdentity:DefaultConnection"]));

            services.AddIdentity<User, IdentityRole>(opts =>
            { opts.Cookies.ApplicationCookie.LoginPath = "/Auth/Login"; })
                 .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddMvc();
            services.AddTransient<IMessage, MessageRepository>();
            services.AddTransient<IMember, MemberRepository>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app) {
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseIdentity();
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            SeedData.EnsurePopulated(app);
        }
    }
}

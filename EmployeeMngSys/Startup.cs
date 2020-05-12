using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMngSys.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeMngSys
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Registered ApplicationDbContext class
            services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("EDBConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 2;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            //Or,
            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 10;
            //    options.Password.RequiredUniqueChars = 3;
            //    options.Password.RequireNonAlphanumeric = false;
            //});
            services.AddMvc();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();//Added UseAuthentication middleware before UseMVC because we want to authenticate users before the request reaches the MVC middleware. 
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    
            });
        }
    }
}

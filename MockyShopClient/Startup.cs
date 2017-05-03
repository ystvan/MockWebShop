using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MockyShopClient.Data;

namespace MockyShopClient
{
    public class Startup
    {
        private readonly IConfigurationRoot configuration;

        public Startup(IHostingEnvironment env)
        {
            configuration = new ConfigurationBuilder()
                                    .AddEnvironmentVariables()
                                    .AddJsonFile(env.ContentRootPath + "/appsettings.json")

                                    //the second parameter boolean set to true tells that this configuration file is OPTIONAL!
                                    //This parameter tells the configuration API that if the file exists at run time, then yeah, 
                                    //sure, go ahead and read it in. 
                                    //Otherwise if the file is missing, just keep going with the configuration that you've already got.
                                    .AddJsonFile(env.ContentRootPath + "/appsettings.development.json", true)
                                    .Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {

             /*
             * Dependency Injection options:
             *  TRANSIENT: 
                 *  AddTransient method will have a transient or the shortest lifespan, 
                 *  as ASP.NET Core will create a new instance every time one is requested. 
             *  SCOPED: 
                 *  the AddScoped method, it generally means that ASP.NET Core will only 
                 *  create one instance of that type for each web request. Sharing state between different
                 *  components components throughout the same request without worrying about another user's
                 *  request gaining access to that same data.
             *  SINGLETON:
                 * the AddSingleton method, this method will only create one instance of each type for 
                 * the entire lifetime of the application, which is helpful in cases when you have some 
                 * common data that you want to share across all users or when you have a type that's 
                 * particularly expensive to create and is not specific to any particular user or request. 
                 
             */
            services.AddTransient<FeatureToggles>(x => new FeatureToggles
            {
                EnableDeveloperExceptions = configuration.GetValue<bool>("FeatureToggles:EnableDeveloperExceptions")
            });
            services.AddMvc(options =>
            {
                options.SslPort = 44311;
                options.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, FeatureToggles features)
        {
            loggerFactory.AddConsole();

            //TODO: implement custom userfriendly error page!
            app.UseExceptionHandler("/error.html");

            //configuration API tricks
            if (features.EnableDeveloperExceptions)
            {
                app.UseDeveloperExceptionPage();
            }

            //TODO: add some static content!
            //rendering any static files content it can be found under the 'wwwroot' folder
            app.UseFileServer();
            app.UseStaticFiles();

            //registering it before the MVC middleware
            app.UseIdentity();

            //We can define the route patterns that the ASP.NET Core MVC middleware should be listening to
            app.UseMvc(routes =>
            {
                routes.MapRoute("Default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;

namespace SGU.NETCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            string[] firstNames = { "juan", "carlos", "pepe", "paola", "ricardo" };
            firstNames.Select(name => name.Firts().ToString().ToUpper() + name.Substring(1));

            Configuration = configuration;
                                  
            FieldInfo runtimeInfo = PlatformServices.Default.Application.RuntimeFramework.GetType().GetField("_theRuntime");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddSessionStateTempDataProvider();
            services.AddSession(options => {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "Sinco";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            string str = "L";
            int cost;
            switch(str){
                case "S":
                    cost = 1;
                    break;
                case "M";
                    cost = 2;
                    break;
                case "L":
                    cost = 3;
                    break;
                default:
                    throw new ArgumentException("Invalid size");
            }
        }
    }

    public class Person{
        
        public string FirstName { get; set;}

        public string LastName { get; set; }

        public int Age { get; set; }

        public string FullName{ get => $"{LastName}, {FirstName}"; }
    }
}

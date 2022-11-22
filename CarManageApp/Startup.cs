using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarManageApp.DatabaseContext;
using CarManageApp.Services;

// https://medium.com/net-core/repository-pattern-implementation-in-asp-net-core-21e01c6664d7
// https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/dependency-injection

namespace CarManageApp {
    /*public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services) where TService : class
        where TImplementation : class, TService;*/
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        /*public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services) 
            where TService : class 
            where TImplementation : class, TService;*/

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarManageApp", Version = "v1" });
            });
            services.AddDbContext<AppDbcontext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("Car_Context")));
            
            //services.AddHttpContextAccessor();
            services.AddScoped<ICarService, CarService>();
            //services.AddScoped<AppDbcontext>();

            //services.AddScoped<CarService>();
            //services.Add(new ServiceDescriptor(typeof(ICarService), typeof(CarService)));
            //services.Add(new ServiceDescriptor(typeof(ICarService), typeof(CarService), ServiceLifetime.Scoped));
            //services.AddScoped<ICarService, CarService>();
            
            ////////////////services.AddScoped<ICarService, CarService>();
            
            //services.AddScoped(typeof(ICarService), typeof(CarService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarManageApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}

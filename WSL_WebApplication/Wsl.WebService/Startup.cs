using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsl.Services.Services;
using WSL.DataBase;
using WSL.DataBase.Repositores;

namespace Wsl.WebService
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
           services.AddDbContext<WSLDBContext>(o => o.UseMySQL("server=mariadb12.iq.pl; port=3306; database=cybertrick_m2; user= 	cybertrick_m2; password=BrqBb9OqbMZcv909H2DI; Persist Security Info=False; Connect Timeout=300;Convert Zero Datetime=true;Character Set=utf8"));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                  builder =>
                  {
                      builder
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowAnyOrigin();
                  });
            });
            services.AddScoped<MaterialTypeService>();
            services.AddScoped<MeasurementService>();



            services.AddScoped<MeasurementRepository>();
            services.AddScoped<MaterialTypeRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wsl.WebService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wsl.WebService v1"));
            }

            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

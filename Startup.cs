using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PBLSecurity;
using PBLSecurity.Services;
using PBLSecurity.Services.Interfaces;
using Test_API.Common;
using Test_API.Data;

namespace Test_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IConfiguration>(Configuration);
            Tools.ConnectionString = Configuration.GetConnectionString("SecurityDB");

            services.AddSwaggerGen();

            services.AddCors(o => o.AddPolicy(Tools.CorsPolicyName, builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            services.AddScoped<ITestInterface, MockTestData>();
            services.AddScoped<ID3ModelManager, D3ModelManager>();
            services.AddScoped<IMockAuthentication, MockAuthentication>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpsRedirection();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseCors(Tools.CorsPolicyName);

            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "App API V1");

            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

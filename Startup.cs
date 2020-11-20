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

            services.AddScoped<ITestInterface, MockTestData>();
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
            }


            // ######## IMPLEMENTED SECURITY HEADERS

            ////app.Use(async (context, next) =>
            ////{
            ////    context.Response.Headers.Add("X-Xss-Protection", "1");
            ////    context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            ////    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            ////    context.Response.Headers.Add("Referrer-Policy", "no-referrer");
            ////    context.Response.Headers.Add("Expect-CT", "max-age=0");
            ////    context.Response.Headers.Add("Feature-Policy",
            ////    "vibrate 'self' ; " +
            ////    "camera 'self' ; " +
            ////    "microphone 'self' ; " +
            ////    "speaker 'self' https://youtube.com https://www.youtube.com ;" +
            ////    "geolocation 'self' ; " +
            ////    "gyroscope 'self' ; " +
            ////    "magnetometer 'self' ; " +
            ////    "midi 'self' ; " +
            ////    "sync-xhr 'self' ; " +
            ////    "push 'self' ; " +
            ////    "notifications 'self' ; " +
            ////    "fullscreen '*' ; " +
            ////    "payment 'self' ; ");

            ////    context.Response.Headers.Add(
            ////    "Content-Security-Policy-Report-Only",
            ////    "default-src 'self'; " +
            ////    "script-src-elem 'self'" +
            ////    "style-src-elem 'self'; " +
            ////    "img-src 'self'; http://www.w3.org/" +
            ////    "font-src 'self'" +
            ////    "media-src 'self'" +
            ////    "frame-src 'self'" +
            ////    "connect-src "

            ////    );
            ////    await next();
            ////});


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

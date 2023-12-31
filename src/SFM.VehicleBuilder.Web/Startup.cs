﻿using ChromeData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SFM.VehicleBuilder.Application;
using SFM.VehicleBuilder.Data;
using SFM.VehicleBuilder.Domain.Correlation;

namespace SFM.VehicleBuilder.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // app.UseDirectoryBrowser();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

                // app.UseHsts();

                // app.UseHttpsRedirection();
            }

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseApiVersioningMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "Default",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                    });
            });

            services.AddSingleton(provider => Configuration);
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddControllers();

            services.AddAuthorization();

            services
                 .AddAuthenticationServices(Configuration)
                 .AddDataServices(Configuration)
                 .AddApplicationServices(Configuration)
                 .AddApiVersioning()
                 .AddScoped(provider => new CorrelationId())
                 ;
        }
    }
}
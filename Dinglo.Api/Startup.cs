using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Dinglo.Api.Configurations;
using NetDevPack.Identity;
using NetDevPack.Identity.Jwt;
using Newtonsoft.Json.Serialization;
using Dinglo.Api.Helper;
using Dinglo.Domain.Entities.Account;
using Dinglo.Infra.Context;
using Dinglo.Domain.Repositories;
using System;
using Newtonsoft.Json;

namespace Dinglo.Api
{
    public class Startup
    {
        public string Env { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env.EnvironmentName;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            
            services.AddDbContext<DingloContext>(opt => 
                opt.UseSqlServer(Configuration.GetConnectionString("Dinglo"),
                    b => b.MigrationsAssembly("Dinglo.Infra")));
            
            services.AddCustomIdentity<UserIdentity>(opt =>
                {
                    opt.Password.RequiredLength = 4;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireLowercase = false;
                })
                .AddDefaultRoles()
                .AddCustomEntityFrameworkStores<DingloContext>()
                .AddDefaultTokenProviders();

            services.AddJwtConfiguration(Configuration, "AppSettings");

            services.AddSwaggerConfiguration();
            services.AddSwaggerGenNewtonsoftSupport();

            ConfigureDI(services, Configuration);
        }

        public static void ConfigureDI(IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDependencies(configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dinglo");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}

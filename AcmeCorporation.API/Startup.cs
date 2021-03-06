﻿using System;
using AcmeCorporation.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AcmeCorporation.API.Data.Contracts;
using AcmeCorporation.API.Data.Repositories;
using AutoMapper;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AcmeCorporation.API.Services;
using AcmeCorporation.API.Helpers;
using System.IO;
using AcmeCorporation.API.LoggerService;
using NLog;
using Microsoft.Extensions.FileProviders;

namespace AcmeCorporation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IAuthService), typeof(AuthService));
            services.AddTransient(typeof(IFileUploadService), typeof(FileUploadService));
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped<MessageHub, MessageHub>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerManager loggerManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.ConfigureExceptionHandler(loggerManager);
            }

            app.UseHttpsRedirection();

            app.UseFileServer(
                new FileServerOptions() {
                    FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/Images"
                });

            
            app.UseCors(x => x.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseAuthentication();
            app.UseMvc();

            app.UseSignalR(options =>  
            {  
                options.MapHub<MessageHub>("/MessageHub");  
            });   
        }
    }
}

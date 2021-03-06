﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace PTMS_WEBAPI
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
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddAzureAdB2CBearer(options => Configuration.Bind("AzureAdB2C", options));

            // UseSqlServer for the database connections
            string connectionstr = Configuration.GetConnectionString("localDb");
            services.AddDbContext<DTO.PTMSDBContext>(opt => opt.UseSqlServer(connectionstr));
            //services.AddDbContext<DTO.PTMSDBContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            // we would be using the singleton for the ado.net model without using the context
            // after using the singleton i have placed a separate Data layer to use the ado.net entity
            //services.AddSingleton<IConfiguration>(Configuration);
            services.AddCors();
            services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver
                    = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });
                }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // app.UseCors( options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader() );
            app.UseCors( options => options.WithOrigins("http://localhost:4300","http://localhost:4200").AllowAnyMethod().AllowAnyHeader() );
            app.UseMvcWithDefaultRoute();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}

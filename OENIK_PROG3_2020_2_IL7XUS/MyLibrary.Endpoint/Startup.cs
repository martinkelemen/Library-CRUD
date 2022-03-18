using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyLibrary.Data;
using MyLibrary.Endpoint.Services;
using MyLibrary.Logic;
using MyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Endpoint
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
            services.AddTransient<DbContext,LibraryContext>();

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IRenterRepository, RenterRepository>();
            services.AddTransient<IWorkerRepository, WorkerRepository>();
            services.AddTransient<IBookRentalRepository, BookRentalRepository>();

            services.AddTransient<ILibraryLogic, LibraryLogic>();
            services.AddTransient<IPersonLogic, PersonLogic>();

            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyLibrary.Endpoint", Version = "v1" });
            });

            //services.AddTransient<DbContext, LibraryContext>();

            //services.AddTransient<IBookRepository, BookRepository>();
            //services.AddTransient<IRenterRepository, RenterRepository>();
            //services.AddTransient<IWorkerRepository, WorkerRepository>();
            //services.AddTransient<IBookRentalRepository, BookRentalRepository>();

            //services.AddTransient<IBookLogic, BookLogic>();
            //services.AddTransient<IRenterLogic, RenterLogic>();
            //services.AddTransient<IWorkerLogic, WorkerLogic>();
            //services.AddTransient<IBookRentalLogic, BookRentalLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyLibrary.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
             {
                 var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                 var response = new { error = exception.Message };
                 await context.Response.WriteAsJsonAsync(response);
             }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}

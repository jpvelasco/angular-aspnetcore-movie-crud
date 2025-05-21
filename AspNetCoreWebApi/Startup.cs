using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// ILoggerFactory is no longer needed here
using Microsoft.Extensions.Hosting; // For IWebHostEnvironment
using Microsoft.EntityFrameworkCore; // Required for AddDbContext and UseInMemoryDatabase
using MovieWebApi.Models; // Required for MovieContext
using System;
using System.Linq;

namespace MovieWebApi
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
            // Add CORS services.
            services.AddCors();

            // Add framework services.
            services.AddControllers(); // Changed from AddMvc()

            // Add Entity Framework Core InMemory DbContext
            services.AddDbContext<MovieWebApi.Models.MovieContext>(options =>
                options.UseInMemoryDatabase("MyData"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // Removed ILoggerFactory, changed IHostingEnvironment
        {
            // NOTE: CORS is configured here to accept from all origins, methods and headers.
            // This setting is used for sample application purposes only.
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            // Logging is configured in Program.cs or via appsettings.json

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization(); // Added for good practice

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Replaces app.UseMvc()
            });
        }
    }
}

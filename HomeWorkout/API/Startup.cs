using API.DataFitness;
using API.DataFitness.Helpers;
using API.DataFitness.Models;
using API.DataFitness.Repositories;
using API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<ICategorisedExerciseRepository, CategorisedExerciseRepository>();
            services.AddScoped<IDayRepository, DayRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IFitnessGoalRepository, FitnessGoalRepository>();
            services.AddScoped<IFitnessLevelRepository, FitnessLevelRepository>();
            services.AddScoped<IUserDietRepository, UserDietRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IFoodTypeRepository, FoodTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDieryRepository, UserDieryRepository>();
            services.AddScoped<IUserWorkoutPlanRepository, UserWorkoutPlanRepository>();
            // SQL.Lite provider for connecting to database
            services.AddDbContext<FitnessContext>(x => x.UseSqlite
            (Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

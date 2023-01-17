using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot;
using webhooktestagain.Commands;
using webhooktestagain.Data;
using webhooktestagain.Interfaces;
using webhooktestagain.Services;

namespace webhooktestagain
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
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Db")), ServiceLifetime.Singleton);
            services.AddSingleton<TelegramBot>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ITrainingService, TrainingService>();
            services.AddSingleton<ICommandExecutor, CommandExecutor>();
            services.AddSingleton<IExerciseService, ExerciseService>();
            services.AddSingleton<BaseCommand, StartCommand>();
            services.AddSingleton<BaseCommand, AddTrainingCommand>();
            services.AddSingleton<BaseCommand, AddExerciseCommand>();
            services.AddSingleton<BaseCommand, GetAllTrainingCommand>();
            services.AddSingleton<BaseCommand, GetExercisesCommand>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            serviceProvider.GetRequiredService<TelegramBot>().GetBot().Wait();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

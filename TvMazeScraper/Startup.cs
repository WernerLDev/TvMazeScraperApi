using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TvMazeScraper.Database;
using TvMazeScraper.Repositories;
using TvMazeScraper.Repositories.interfaces;
using Hangfire;
using TvMazeScraper.HangfireJobs;
using Hangfire.MemoryStorage;
using TvMazeScraper.ApiClients.TvMazeApi;
using Hangfire.AspNetCore;
using TvMazeScraper.services;

namespace TvMazeScraper
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
            services.AddDbContext<TvMazeDbContext>();
            services.AddScoped<IShowsRepository, ShowsRepository>();
            services.AddScoped<ICastRepository, CastRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IShowService, ShowService>();
            services.AddScoped<ITvMazeApi, TvMazeApi>();
            services.AddScoped<IScrapeTvMazeData, ScrapeTvMazeData>();
            services.AddOptions();

            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddHangfire(configuration => configuration
                .UseMemoryStorage());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHangfireServer();

            RecurringJob.AddOrUpdate<IScrapeTvMazeData>(scraper =>
                scraper.ScrapeData(), Cron.Daily);

            BackgroundJob.Enqueue<IScrapeTvMazeData>(scraper => 
                scraper.ScrapeData());
            

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

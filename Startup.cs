using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Data.Entity;
using FiDeLo3.Resources.Curriculums.Models;
using Newtonsoft.Json.Serialization;

namespace FiDeLo3.Resources.Curriculums
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Uncomment following line to enable in memory storing for EntityFramework7
            services.AddEntityFramework().AddInMemoryDatabase().AddDbContext<CurriculumsDbContext>(options => options.UseInMemoryDatabase());
            
            // Uncomment following line to enable SqLite adapter for EntityFramework7        
            //  services.AddEntityFramework().AddSqlite().AddDbContext<CurriculumsDbContext>(options => options.UseSqlite("Data Source=curriculumsDataBase.sqlite;"));
            
            // Uncomment following line to enable in PostgreSql adapter for EntityFramework7         
            //  services.AddEntityFramework().AddNpgsql().AddDbContext<CurriculumsDbContext>(options => options.UseNpgsql("connectionString"));
            
            // Adding mvc and serialization / json rules
            services.AddMvc()
            .AddJsonOptions(option => option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            //   .AddJsonOptions(option => option.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects);
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            
            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();
            
            CreateMockedData(app.ApplicationServices).Wait();
        }
        
        /// Injecting some extra mocked data at the server start
        private static async Task CreateMockedData(IServiceProvider applicationServices)
        {
            using (var dbContext = applicationServices.GetService<CurriculumsDbContext>())
            {
                if (dbContext.Curriculums.Any())
                {
                    dbContext.Curriculums.RemoveRange(dbContext.Curriculums);
                    dbContext.SaveChanges();                    
                }
                    
                
                
                
                var semester = new Semester 
                {
                    Id = 23,
                    CurriculumId = 10,
                    OrderNumber = 1,
                    Courses = 
                    {
                        new Course
                        {
                            Id = 0,
                            Name = "Sieci Komputerowe",
                            LectureHours = 16,
                            ClassesHours = 0,
                            LaboratoriesHours  = 16,
                            HasExam = true,
                            EctsPoints = 5,
                            IsForeignLanguage = false,
                            IsSportType = false
                        }
                    }
                };
                
                var curriculums = new List<Curriculum>
                {
                    new Curriculum 
                    {
                        Id = 10, 
                        Name = "Curriculum Inf Bachelors",
                        Semesters = new[]{ semester }
                    }
                };
                curriculums.ForEach(m => dbContext.Curriculums.Add(m));
                dbContext.SaveChanges();
            }
        }
    }
}
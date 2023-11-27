using Bank4Us.BusinessLayer.Core;
using Bank4Us.BusinessLayer.Managers.MortgageManagement;
using Bank4Us.BusinessLayer.Managers.MortgageApplicantManagement;
using Bank4Us.BusinessLayer.Managers.CreditReportManagement;
using Bank4Us.BusinessLayer.Managers.LoanOfficerManagement;
using Bank4Us.BusinessLayer.Managers.PersonManagement;
using Bank4Us.BusinessLayer.Rules;
using Bank4Us.DataAccess.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NRules;
using NRules.Fluent;
using Microsoft.OpenApi.Models;

namespace Bank4Us.ServiceApp
{
    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of a Service App with MVC           
    /// </summary>
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
            // Enable Cross-Origin Requests (CORS) in ASP.NET Core
            //https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            //INFO: BRE example implementation.  
            // https://github.com/NRules/NRules/wiki/Getting-Started
            var ruleset = new RuleRepository();
            ruleset.Load(x => x.From(typeof(AdultApplyRule).Assembly));

            //Compile rules
            var brefactory = ruleset.Compile();

            //Create a working session
            ISession businessRulesEngine = brefactory.CreateSession();


            //INFO: Dependency injection is a technique that follows the Dependency Inversion
            //      Principle, allowing for applications to be composed of loosely coupled modules.
            //     ASP.NET Core has built-in support for dependency injection, which makes applications
            //    easier to test and maintain.
            //  https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection?view=aspnetcore-2.1

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<DataContext>();
            services.AddScoped<IRepository, Repository>();
            services.AddSingleton<ISession>(businessRulesEngine);
            services.AddScoped<IMortgageApplicantManager, MortgageApplicantManager>();
            services.AddScoped<IMortgageManager, MortgageManager>();
            services.AddScoped<ILoanOfficerManager, LoanOfficerManager>();
            services.AddScoped<ICreditReportManager, CreditReportManager>();
            services.AddScoped<IPersonManager, PersonManager>();
            services.AddScoped<BusinessManagerFactory>();

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                ;

            //INFO:Register the Swagger generator, defining 1 or more Swagger documents
            //https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.1&tabs=visual-studio%2Cvisual-studio-xml
            services.AddSwaggerGen(c =>
            {   
                //c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank4Us API", Version = "V1" });

            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //INFO: DotNet Core 3.1 loggerFactory setup.
            LoggerFactory.Create(builder => {
                builder.AddFilter("Microsoft", LogLevel.Warning)
                       .AddFilter("System", LogLevel.Warning)
                       .AddFilter("Bank4Us.ServiceApp.Program", LogLevel.Debug)
                       .AddConsole();
                                            }
            );
            // Enable Cross-Origin Requests (CORS) in ASP.NET Core
            //https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //INFO: Enable middleware to serve generated Swagger as a JSON endpoint.
            // https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.1&tabs=visual-studio%2Cvisual-studio-xml
            app.UseSwagger();

            //INFO: Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            //INFO: specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bank4Us API V1");
               
            });
            
            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}

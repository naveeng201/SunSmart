using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SunsmartAWSServerless.DataAccess;
using SunsmartAWSServerless.DataManager;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Interfaces;
using SunsmartAWSServerless.Services;

namespace SunsmartAWSServerless
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add S3 to the ASP.NET Core dependency injection framework.
            services.AddAWSService<Amazon.S3.IAmazonS3>();

            // Bind your sunsmart services.
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICatalogueService, CatalogueService>();
            services.AddScoped<IWindowFunctionalityService, WindowfunctionalityService>();
            services.AddScoped<IWindowShapeService, WindowShapeService>();
            services.AddScoped<IMeasurementService, MeasurementService>();
            services.AddScoped<IProjectService, ProjectService>();


            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<SunsmartContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SunSmartDB")));
            services.AddScoped(typeof(IRepository<TUsers>), typeof(Repository<TUsers>));
            services.AddScoped(typeof(IRepository<TCustomer>), typeof(Repository<TCustomer>));
            services.AddScoped(typeof(IRepository<TCatalogue>), typeof(Repository<TCatalogue>));
            services.AddScoped(typeof(IRepository<TWindowsfunctionality>), typeof(Repository<TWindowsfunctionality>));
            services.AddScoped(typeof(IRepository<TWindowsShape>), typeof(Repository<TWindowsShape>));
            services.AddScoped(typeof(IRepository<TMeasurements>), typeof(Repository<TMeasurements>));
            services.AddScoped(typeof(IRepository<TProjects>), typeof(Repository<TProjects>));

            services.AddScoped(typeof(IUserDataManager), typeof(UserDataManager));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

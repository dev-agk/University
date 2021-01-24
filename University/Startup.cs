using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using University.BusinessLayer.Interfaces;
using University.BusinessLayer.Services;
using University.Interfaces;
using University.PresentationLayer.Interfaces;
using University.PresentationLayer.Services;
using University.Services;

namespace University
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
            services.AddControllersWithViews();

            //Registering application db as singelton as we have inApp model as a data-source.
            services.AddSingleton<IDataInterface, InApplicationDataAccessService>();

            //Registering logger service
            services.AddSingleton<ILoggerInterface, LoggerService>();


            #region CRUD Services
            services.AddSingleton<IStudentsInterface, StudentService>();

            services.AddSingleton<ICoursesInterface, CourseService>();

            services.AddSingleton<IStudentCoursesInterface, StudentCoursesService>();
            #endregion

            //Registering BL Service
            services.AddSingleton<IStudentCoursesBLInterface, StudentCourseBLService>();


            //Registering Reporting Service
            services.AddSingleton<IReportInterface, ReportService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Report}/{id?}");
            });
        }
    }
}

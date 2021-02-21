using Businness;
using Businness.Abstract;
using Businness.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            //services.AddSingleton<ICarService, CarManager>();
            //services.AddSingleton<IBrandsService, BrandsManager>();
            //services.AddSingleton<IColorsService, ColorsManager>();
            //services.AddSingleton<IRentalsService, RentalsManager>();
            //services.AddSingleton<IUsersService, UsersManager>();

            //services.AddSingleton<ICarDal, EFCarDal>();
            //services.AddSingleton<IBrandsDal, EFBrandsDal>();
            //services.AddSingleton<IColorsDal, EFColorsDal>();
            //services.AddSingleton<IRentalsDal, EFRentalsDal>();
            //services.AddSingleton<IUsersDal, EFUsersDal>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

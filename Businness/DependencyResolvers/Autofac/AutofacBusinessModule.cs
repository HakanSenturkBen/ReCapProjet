using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Businness.Abstract;
using Businness.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using static Business.Concrete.AuthManager;

namespace Businness.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EFCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<BrandsManager>().As<IBrandsService>().SingleInstance();
            builder.RegisterType<EFBrandsDal>().As<IBrandsDal>().SingleInstance();

            builder.RegisterType<ColorsManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EFColorsDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<RentalsManager>().As<IRentalsService>().SingleInstance();
            builder.RegisterType<EFRentalsDal>().As<IRentalsDal>().SingleInstance();

            builder.RegisterType<UsersManager>().As<IUsersService>().SingleInstance();
            builder.RegisterType<EFUsersDal>().As<IUsersDal>().SingleInstance();

            builder.RegisterType<CarImagesManager>().As<ICarImagesService>().SingleInstance();
            builder.RegisterType<EfCarImagesDal>().As<ICarImagesDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<CarInfoDetailManager>().As<ICarInfoDetailService>();
            builder.RegisterType<EfCarInfoDetail>().As<ICarInfoDetailDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<BankPaymetManager>().As<IBankPaymentService>();
            builder.RegisterType<EfBankPaymentDal>().As<IBankPaymentDal>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

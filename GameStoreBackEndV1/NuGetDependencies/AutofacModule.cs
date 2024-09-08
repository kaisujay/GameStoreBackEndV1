using Autofac;
using GameStoreBackEndV1.ServiceLogic.CountryService;
using GameStoreBackEndV1.ServiceLogic.EmailService;
using GameStoreBackEndV1.ServiceLogic.ExceptionService.ExceptionHandling;

namespace GameStoreBackEndV1.NuGetDependencies
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<Test>().AsImplementedInterfaces().SingleInstance(); //Auto Search the Interface
            //builder.RegisterType<Test>().As<ITest>().SingleInstance();             //Singleton
            //builder.RegisterType<Test>().As<ITest>().InstancePerLifetimeScope();   //Scoped
            //builder.RegisterType<Test>().As<ITest>().InstancePerDependency();      //Transient

            builder.RegisterType<ExceptionHandleMiddleware>().InstancePerDependency();

            builder.RegisterType<EmailService>().As<IEmailService>().InstancePerLifetimeScope();
            builder.RegisterType<CountryService>().As<ICountryService>().SingleInstance();
        }
    }
}

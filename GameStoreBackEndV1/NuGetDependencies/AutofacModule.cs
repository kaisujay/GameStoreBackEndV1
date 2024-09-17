using Autofac;
using GameStoreBackEndV1.DataLogic.Cart;
using GameStoreBackEndV1.DataLogic.Game;
using GameStoreBackEndV1.DataLogic.GamePlatformType;
using GameStoreBackEndV1.DataLogic.PlatformType;
using GameStoreBackEndV1.DataLogic.Player;
using GameStoreBackEndV1.DataLogic.PlayerRole;
using GameStoreBackEndV1.DataLogic.Rating;
using GameStoreBackEndV1.DataLogic.Role;
using GameStoreBackEndV1.DataLogic.WishList;
using GameStoreBackEndV1.ServiceLogic.CartService;
using GameStoreBackEndV1.ServiceLogic.CountryService;
using GameStoreBackEndV1.ServiceLogic.EmailService;
using GameStoreBackEndV1.ServiceLogic.ExceptionService.ExceptionHandling;
using GameStoreBackEndV1.ServiceLogic.GamePlatformTypeService;
using GameStoreBackEndV1.ServiceLogic.GameService;
using GameStoreBackEndV1.ServiceLogic.PlatformTypeService;
using GameStoreBackEndV1.ServiceLogic.PlayerRoleService;
using GameStoreBackEndV1.ServiceLogic.PlayerService;
using GameStoreBackEndV1.ServiceLogic.RatingService;
using GameStoreBackEndV1.ServiceLogic.RoleService;
using GameStoreBackEndV1.ServiceLogic.WishListService;

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

            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PlayerService>().As<IPlayerService>().InstancePerLifetimeScope();

            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();

            builder.RegisterType<PlayerRoleRepository>().As<IPlayerRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PlayerRoleService>().As<IPlayerRoleService>().InstancePerLifetimeScope();

            builder.RegisterType<GameRepository>().As<IGameRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GameService>().As<IGameService>().InstancePerLifetimeScope();

            builder.RegisterType<PlatformTypeService>().As<IPlatformTypeService>().InstancePerLifetimeScope();
            builder.RegisterType<PlatformTypeRepository>().As<IPlatformTypeRepository>().InstancePerLifetimeScope();

            builder.RegisterType<GamePlatformTypeRepository>().As<IGamePlatformTypeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GamePlatformTypeService>().As<IGamePlatformTypeService>().InstancePerLifetimeScope();

            builder.RegisterType<CartRepository>().As<ICartRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CartService>().As<ICartService>().InstancePerLifetimeScope();

            builder.RegisterType<WishListRepository>().As<IWishListRepository>().InstancePerLifetimeScope();
            builder.RegisterType<WishListService>().As<IWishListService>().InstancePerLifetimeScope();

            builder.RegisterType<RatingRepository>().As<IRatingRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RatingService>().As<IRatingService>().InstancePerLifetimeScope();
        }
    }
}

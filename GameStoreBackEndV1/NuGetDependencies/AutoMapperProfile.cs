using AutoMapper;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.NuGetDependencies
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Role
            CreateMap<RoleTableDataModel, CreateRoleDto>().ReverseMap();
            CreateMap<RoleTableDataModel, DisplayRoleDto>().ReverseMap();

            //PlayerRole
            CreateMap<PlayerRoleTableDataModel, CreatePlayerRoleDto>().ReverseMap();
            CreateMap<PlayerRoleTableDataModel, DisplayPlayerRoleDto>().ReverseMap();

            //Player
            CreateMap<CreatePlayerDto, PlayerTableDataModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))      // This is BAD
                .ReverseMap()
                .ForMember(dest => dest.FirstName, opt => opt.Ignore()) //Use "ForPath" maybe ?
                .ForMember(dest => dest.LastName, opt => opt.Ignore())
                .ForMember(dest => dest.ConfirmEmail, opt => opt.Ignore())
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore());

            CreateMap<UpdatePlayerDto, PlayerTableDataModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ReverseMap()
                .ForMember(dest => dest.FirstName, opt => opt.Ignore())
                .ForMember(dest => dest.LastName, opt => opt.Ignore());
            CreateMap<PlayerTableDataModel, ResetPasswordPlayerDto>().ReverseMap();
            CreateMap<PlayerTableDataModel, DisplayPlayerDto>().ReverseMap();

            //Cart
            CreateMap<CartDataModel, CreateAndUpdateCartDto>().ReverseMap();
            CreateMap<CartDataModel, DisplayCartDto>().ReverseMap();

            //Game
            CreateMap<GameDataModel, CreateAndUpdateGameDto>().ReverseMap();
            CreateMap<GameDataModel, DisplayGameDto>().ReverseMap();

            //GamePlatformType
            CreateMap<GamePlatformTypeDataModel, CreateGamePlatformTypeDto>().ReverseMap();
            CreateMap<GamePlatformTypeDataModel, DisplayGamePlatformTypeDto>().ReverseMap();

            //PlatformType
            CreateMap<PlatformTypeDataModel, CreatePlatformTypeDto>().ReverseMap();
            CreateMap<PlatformTypeDataModel, DisplayPlatformTypeDto>().ReverseMap();

            //OrderHistory
            CreateMap<OrderHistoryDataModel, CreateOrderHistoryDto>().ReverseMap();
            CreateMap<OrderHistoryDataModel, DisplayOrderHistoryDto>().ReverseMap();

            //Rating
            CreateMap<RatingDataModel, CreateRatingDto>().ReverseMap();
            CreateMap<RatingDataModel, DisplayRatingDto>().ReverseMap();

            //WishList
            CreateMap<WishListDataModel, CreateWishListDto>().ReverseMap();
            CreateMap<WishListDataModel, DisplayWishListDto>().ReverseMap();
        }
    }
}

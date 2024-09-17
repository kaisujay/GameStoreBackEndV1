using AutoMapper;
using GameStoreBackEndV1.ObjectLogic.ObjectDTOs.Country;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.NuGetDependencies
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Role
            CreateMap<RoleTableDataModel, RoleDto>().ReverseMap();
            CreateMap<RoleDto, CreateRoleDto>().ReverseMap();
            CreateMap<RoleDto, DisplayRoleDto>().ReverseMap();

            //PlayerRole
            CreateMap<PlayerRoleTableDataModel, PlayerRoleDto>().ReverseMap();
            CreateMap<PlayerRoleTableDataModel, PlayerRoleTableDto>().ReverseMap();
            CreateMap<PlayerRoleDto, PlayerRoleTableDto>().ReverseMap();
            CreateMap<PlayerRoleDto, DisplayPlayerRoleDto>().ReverseMap();

            //Player
            CreateMap<PlayerDto, PlayerTableDataModel>().ReverseMap();
            CreateMap<CreatePlayerDto, PlayerDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))      // This is BAD
                .ReverseMap()
                .ForMember(dest => dest.FirstName, opt => opt.Ignore()) //Use "ForPath" maybe ?
                .ForMember(dest => dest.LastName, opt => opt.Ignore())
                .ForMember(dest => dest.ConfirmEmail, opt => opt.Ignore())
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore());

            CreateMap<UpdatePlayerDto, PlayerDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ReverseMap()
                .ForMember(dest => dest.FirstName, opt => opt.Ignore())
                .ForMember(dest => dest.LastName, opt => opt.Ignore());
            CreateMap<PlayerDto, ResetPasswordPlayerDto>().ReverseMap();
            CreateMap<PlayerDto, DisplayPlayerDto>().ReverseMap();

            //Cart
            CreateMap<CartDataModel, CartDto>().ReverseMap();
            CreateMap<CartDto, CreateAndUpdateCartDto>().ReverseMap();
            CreateMap<CartDto, DisplayCartDto>()
                .ForMember(dest => dest.Games, opt => opt.MapFrom(src => src.Game))
                .ReverseMap();

            //Game
            CreateMap<GameDataModel, GameDto>().ReverseMap();
            CreateMap<GameDto, CreateAndUpdateGameDto>().ReverseMap();
            CreateMap<GameDto, DisplayGameDto>().ReverseMap();

            //GamePlatformType
            CreateMap<GamePlatformTypeDataModel, GamePlatformTypeDto>().ReverseMap();
            CreateMap<GamePlatformTypeDto, CreateGamePlatformTypeDto>().ReverseMap();
            CreateMap<GamePlatformTypeDto, DisplayGamePlatformTypeDto>().ReverseMap();

            //PlatformType
            CreateMap<PlatformTypeDataModel, PlatformTypeDto>().ReverseMap();
            CreateMap<PlatformTypeDto, CreatePlatformTypeDto>().ReverseMap();
            CreateMap<PlatformTypeDto, DisplayPlatformTypeDto>().ReverseMap();

            //OrderHistory
            CreateMap<OrderHistoryDataModel, OrderHistoryDto>()
                .ForMember(dest => dest.Games, opt => opt.MapFrom(src => src.Game))
                .ReverseMap();
            CreateMap<OrderHistoryDto, CreateOrderHistoryDto>().ReverseMap();
            CreateMap<OrderHistoryDto, DisplayOrderHistoryDto>().ReverseMap();

            //Rating
            CreateMap<RatingDataModel, RatingDto>().ReverseMap();
            CreateMap<RatingDto, CreateRatingDto>().ReverseMap();
            CreateMap<RatingDto, DeleteRatingDto>().ReverseMap();
            CreateMap<RatingDto, DisplayRatingDto>()
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.Player.FullName))
                .ForMember(dest => dest.PlayerEmail, opt => opt.MapFrom(src => src.Player.Email))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.Player.PlayerId))
                .ForMember(dest => dest.GameName, opt => opt.MapFrom(src => src.Game.Name))
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.Game.GameId))
                .ReverseMap();

            //WishList
            CreateMap<WishListDataModel, WishListDto>().ReverseMap();
            CreateMap<WishListDto, CreateWishListDto>().ReverseMap();
            CreateMap<WishListDto, WishListOnlyIdDto>().ReverseMap();
            CreateMap<WishListDto, DisplaySingleWishListDto>().ReverseMap();
            CreateMap<WishListDto, DisplayWishListDto>().ReverseMap();

            //Country
            CreateMap<CountryDto, DisplayCountryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Common))
                .ForPath(dest => dest.Currency.Name, opt => opt.MapFrom(src => src.Currencies.Shp.Name))        // Use of "ForPath", here with "ForMember" error
                .ForPath(dest => dest.Currency.Symbol, opt => opt.MapFrom(src => src.Currencies.Shp.Symbol))
                .ForMember(dest => dest.GoogleMaps, opt => opt.MapFrom(src => src.Maps.GoogleMaps))
                .ForMember(dest => dest.TimeZones, opt => opt.MapFrom(src => src.Timezones))
                .ForMember(dest => dest.Flag, opt => opt.MapFrom(src => src.Flags.Png))
                .ReverseMap();
        }
    }
}

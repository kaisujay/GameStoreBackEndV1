using Autofac.Core;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.GenericInterfaceService;

namespace GameStoreBackEndV1.ServiceLogic.PlayerService
{
    public interface IPlayerService : IService<PlayerDto, CreatePlayerDto, UpdatePlayerDto, DisplayPlayerDto>
    {
        Task<DisplayPlayerDto> GetByUserNameAsync(string userName);

        Task<DisplayPlayerDto> GetByEmailAsync(string email);

        Task<DisplayPlayerDto> GetByPhoneNumberAsync(string phoneNumber);

        Task<IList<DisplayPlayerDto>> GetAllDateOfBirthAsync(DateTime date);

        Task<DisplayPlayerDto> UpdateWalletBalanceAsync(Guid id, float balance);
    }
}

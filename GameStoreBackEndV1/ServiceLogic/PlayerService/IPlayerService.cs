using Autofac.Core;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.GenericInterfaceService;

namespace GameStoreBackEndV1.ServiceLogic.PlayerService
{
    public interface IPlayerService : IService<PlayerDto, CreatePlayerDto, UpdatePlayerDto, DisplayPlayerDto>
    {
        Task<PlayerDto> GetByUserNameAsync(string userName);

        Task<PlayerDto> GetByEmailAsync(string email);

        Task<PlayerDto> GetByPhoneNumberAsync(string phoneNumber);

        Task<IList<PlayerDto>> GetAllDateOfBirthAsync(DateTime date);

        Task<PlayerDto> UpdateWalletBalanceAsync(Guid id, float balance);
    }
}

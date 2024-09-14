using GameStoreBackEndV1.DataLogic.GenericInterface;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.DataLogic.Player
{
    public interface IPlayerRepository : IRepository<PlayerDto>
    {
        Task<PlayerDto> GetByUserNameAsync(string userName);

        Task<PlayerDto> GetByEmailAsync(string email);

        Task<PlayerDto> GetByPhoneNumberAsync(string phoneNumber);

        Task<IList<PlayerDto>> GetAllDateOfBirthAsync(DateTime date);
    }
}

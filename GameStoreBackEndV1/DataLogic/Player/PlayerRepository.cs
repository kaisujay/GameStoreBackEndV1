using AutoMapper;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.DataLogic.Player
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public PlayerRepository(GameStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<PlayerDto>> GetAllAsync()
        {
            var result = await _dbContext.Players.ToListAsync();
            if (result == null)
            {
                throw new NotFoundException("Players not found");
            }
            var mappedResult = _mapper.Map<IList<PlayerDto>>(result);

            return mappedResult;
        }

        public async Task<PlayerDto> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Players.AsNoTracking().FirstOrDefaultAsync(x=>x.PlayerId == id);      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("Player is not found");
            }
            var mappedResult = _mapper.Map<PlayerDto>(result);

            return mappedResult;
        }

        public async Task<PlayerDto> GetByEmailAsync(string email)
        {
            var result = await _dbContext.Players.Where(x => string.Equals(x.Email, email, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new NotFoundException("Player is not found with given Email");
            }
            var mappedResult = _mapper.Map<PlayerDto>(result);

            return mappedResult;
        }

        public async Task<PlayerDto> GetByPhoneNumberAsync(string phoneNumber)
        {
            var result = await _dbContext.Players.Where(x => x.Phone == phoneNumber).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new NotFoundException("Player is not found with given Phone Number");
            }
            var mappedResult = _mapper.Map<PlayerDto>(result);

            return mappedResult;
        }

        public async Task<PlayerDto> GetByUserNameAsync(string userName)
        {
            var result = await _dbContext.Players.Where(x => string.Equals(x.UserName, userName, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new NotFoundException("Player is not found with given UserName");
            }
            var mappedResult = _mapper.Map<PlayerDto>(result);

            return mappedResult;
        }

        public async Task<IList<PlayerDto>> GetAllDateOfBirthAsync(DateTime date)
        {
            var result = await _dbContext.Players.Where(x => x.DateOfBirth >= date).ToListAsync();
            if (result == null)
            {
                throw new NotFoundException("Players not found with given Date");
            }
            var mappedResult = _mapper.Map<IList<PlayerDto>>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(PlayerDto entity)
        {
            var mappedPlayer = _mapper.Map<PlayerTableDataModel>(entity);
            _dbContext.Players.Add(mappedPlayer);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Player save changes failed");
            }

            return entity.PlayerId;
        }

        public async Task<PlayerDto> UpdateAsync(PlayerDto entity)
        {
            var baseEntry = await GetByIdAsync(entity.PlayerId);
            var mappedBaseEntry = _mapper.Map<PlayerTableDataModel>(baseEntry);
            var mappedPlayer = _mapper.Map<PlayerTableDataModel>(entity);

            _dbContext.Entry(mappedBaseEntry).CurrentValues.SetValues(mappedPlayer);        //Very IMP while Update
            _dbContext.Entry(mappedBaseEntry).State = EntityState.Modified;                 //Very IMP while Update

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Player update changes failed");
            }

            return await GetByIdAsync(entity.PlayerId);
        }

        public async Task DeleteAsync(PlayerDto entity)
        {
            var mappedPlayer = _mapper.Map<PlayerTableDataModel>(entity);
            _dbContext.Players.Remove(mappedPlayer);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Player delete failed");
            }
        }
    }
}

using AutoMapper;
using GameStoreBackEndV1.DataLogic.Player;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GameStoreBackEndV1.ServiceLogic.PlayerService
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<IList<DisplayPlayerDto>> GetAllAsync()
        {
            var result = await _playerRepository.GetAllAsync();
            var mappedResult = _mapper.Map<IList<DisplayPlayerDto>>(result);

            return mappedResult;
        }

        public async Task<DisplayPlayerDto> GetByIdAsync(Guid id)
        {
            var result = await _playerRepository.GetByIdAsync(id);
            var mappedResult = _mapper.Map<DisplayPlayerDto>(result);

            return mappedResult;
        }

        public async Task<DisplayPlayerDto> GetByEmailAsync(string email)
        {
            var result = await _playerRepository.GetByEmailAsync(email);
            var mappedResult = _mapper.Map<DisplayPlayerDto>(result);

            return mappedResult;
        }

        public async Task<DisplayPlayerDto> GetByPhoneNumberAsync(string phoneNumber)
        {
            var result = await _playerRepository.GetByPhoneNumberAsync(phoneNumber);
            var mappedResult = _mapper.Map<DisplayPlayerDto>(result);

            return mappedResult;
        }

        public async Task<DisplayPlayerDto> GetByUserNameAsync(string userName)
        {
            var result = await _playerRepository.GetByUserNameAsync(userName);
            var mappedResult = _mapper.Map<DisplayPlayerDto>(result);

            return mappedResult;
        }

        public async Task<IList<DisplayPlayerDto>> GetAllDateOfBirthAsync(DateTime date)
        {
            var result = await _playerRepository.GetAllDateOfBirthAsync(date);
            var mappedResult = _mapper.Map<IList<DisplayPlayerDto>>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(CreatePlayerDto entity)
        {
            var payerId = Guid.NewGuid();
            var mappedPlayer = _mapper.Map<PlayerDto>(entity);

            mappedPlayer.PlayerId = payerId;

            var newCreatedGuid = await _playerRepository.CreateAsync(mappedPlayer);

            return newCreatedGuid;
        }

        public async Task<DisplayPlayerDto> UpdateAsync(Guid id, UpdatePlayerDto entity)
        {
            var selectedPlayer = await _playerRepository.GetByIdAsync(id);
            var mappedPlayer = _mapper.Map<PlayerDto>(entity);

            mappedPlayer.PlayerId = selectedPlayer.PlayerId;                // This has tobe manual
            mappedPlayer.PasswordHash = selectedPlayer.PasswordHash;        // This is mistake, should not have been Manual
            mappedPlayer.Wallet = selectedPlayer.Wallet;                    // This too is mistake, should not have been Manual

            var res = await _playerRepository.UpdateAsync(mappedPlayer);

            return _mapper.Map<DisplayPlayerDto>(res);
        }

        public async Task DeleteAsync(Guid id)
        {
            var selectedPlayer = await _playerRepository.GetByIdAsync(id);
            if (selectedPlayer == null)
            {
                throw new NotFoundException("Selected Player to be deleted Not Found");
            }

            await _playerRepository.DeleteAsync(selectedPlayer);
        }

        public async Task<DisplayPlayerDto> UpdateWalletBalanceAsync(Guid id, float walletBalance)
        {
            var selectedPlayer = await _playerRepository.GetByIdAsync(id);
            if (selectedPlayer == null)
            {
                throw new NotFoundException("Selected Player to be deleted Not Found");
            }

            selectedPlayer.Wallet += walletBalance;

            var res = await _playerRepository.UpdateAsync(selectedPlayer);
            if (res == null)
            {
                throw new NotFoundException("Updating Wallet balance failed");
            }

            return _mapper.Map<DisplayPlayerDto>(res);
        }
    }
}

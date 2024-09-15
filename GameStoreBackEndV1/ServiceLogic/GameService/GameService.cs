using AutoMapper;
using GameStoreBackEndV1.DataLogic.Game;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.ServiceLogic.GameService
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<IList<DisplayGameDto>> GetAllAsync()
        {
            var result = await _gameRepository.GetAllAsync();
            var mappedResult = _mapper.Map<IList<DisplayGameDto>>(result);

            return mappedResult;
        }

        public async Task<DisplayGameDto> GetByIdAsync(Guid id)
        {
            var result = await _gameRepository.GetByIdAsync(id);
            var mappedResult = _mapper.Map<DisplayGameDto>(result);

            return mappedResult;
        }

        public async Task<IList<DisplayGameDto>> GetAllByNameAsync(string gameName)
        {
            var result = await _gameRepository.GetAllByNameAsync(gameName);
            var mappedResult = _mapper.Map<IList<DisplayGameDto>>(result);

            return mappedResult;
        }

        public async Task<DisplayGameDto> GetOneByNameAsync(string gameName)
        {
            var result = await _gameRepository.GetOneByNameAsync(gameName);
            var mappedResult = _mapper.Map<DisplayGameDto>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(CreateAndUpdateGameDto entity)
        {
            var gameId = Guid.NewGuid();
            var mappedGame = _mapper.Map<GameDto>(entity);

            mappedGame.GameId = gameId;

            var newCreatedGuid = await _gameRepository.CreateAsync(mappedGame);

            return newCreatedGuid;
        }

        public async Task<GameDto> UpdateAsync(Guid id, CreateAndUpdateGameDto entity)
        {
            var selectedGame = await _gameRepository.GetByIdAsync(id);
            var mappedGame = _mapper.Map<GameDto>(entity);

            mappedGame.GameId = selectedGame.GameId;                    // This has to be manual

            var res = await _gameRepository.UpdateAsync(mappedGame);

            return _mapper.Map<GameDto>(res);
        }
    }
}

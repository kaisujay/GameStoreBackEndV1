using AutoMapper;
using GameStoreBackEndV1.DataLogic.Rating;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;

namespace GameStoreBackEndV1.ServiceLogic.RatingService
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<IList<DisplayRatingDto>> GetAllAsync()
        {
            var result = await _ratingRepository.GetAllAsync();
            var mappedResult = _mapper.Map<IList<DisplayRatingDto>>(result);

            return mappedResult;
        }

        public async Task<DisplayRatingDto> GetByIdAsync(Guid id)
        {
            var result = await _ratingRepository.GetByIdAsync(id);
            var mappedResult = _mapper.Map<DisplayRatingDto>(result);

            return mappedResult;
        }

        public async Task<IList<DisplayRatingDto>> GetByGameIdAsync(Guid id)
        {
            var result = await _ratingRepository.GetByGameIdAsync(id);
            var mappedResult = _mapper.Map<IList<DisplayRatingDto>>(result);

            return mappedResult;
        }

        public async Task<IList<DisplayRatingDto>> GetByPlayerIdAsync(Guid id)
        {
            var result = await _ratingRepository.GetByPlayerIdAsync(id);
            var mappedResult = _mapper.Map<IList<DisplayRatingDto>>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(CreateRatingDto entity)
        {
            var mappedRating = _mapper.Map<RatingDto>(entity);
            mappedRating.RatingId = Guid.NewGuid();

            var checkExists = await _ratingRepository.GetByPlayerIdAndGameIdAsync(entity.PlayerId, entity.GameId);
            if (checkExists != null)
            {
                throw new NotFoundException("Rating already Exists");
            }

            var res = await _ratingRepository.CreateAsync(mappedRating);

            return res;
        }

        public async Task RemoveAsync(DeleteRatingDto entity)
        {
            var selectedItem = await _ratingRepository.GetByPlayerIdAndGameIdAsync(entity.PlayerId, entity.GameId);            
            if (selectedItem == null)
            {
                throw new NotFoundException("Selected Rating Game to be deleted Not Found");
            }

            await _ratingRepository.DeleteAsync(selectedItem);
        }
    }
}

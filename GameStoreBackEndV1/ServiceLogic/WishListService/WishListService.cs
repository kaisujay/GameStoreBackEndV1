using AutoMapper;
using GameStoreBackEndV1.DataLogic.WishList;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;

namespace GameStoreBackEndV1.ServiceLogic.WishListService
{
    public class WishListService : IWishListService
    {
        private readonly IWishListRepository _wishListRepository;
        private readonly IMapper _mapper;

        public WishListService(IWishListRepository WishListRepository, IMapper mapper)
        {
            _wishListRepository = WishListRepository;
            _mapper = mapper;
        }

        public async Task<IList<WishListDto>> GetAllAsync()
        {
            var result = await _wishListRepository.GetAllAsync();
            var mappedResult = _mapper.Map<IList<WishListDto>>(result);

            return mappedResult;
        }

        public async Task<IList<DisplaySingleWishListDto>> GetByGameIdAsync(Guid id)
        {
            var result = await _wishListRepository.GetByGameIdAsync(id);
            var mappedResult = _mapper.Map<IList<DisplaySingleWishListDto>>(result);

            return mappedResult;
        }

        public async Task<DisplayWishListDto> GetByPlayerIdAsync(Guid id)
        {
            var result = await _wishListRepository.GetByPlayerIdAsync(id);
            var mappedResult = _mapper.Map<DisplayWishListDto>(result);

            return mappedResult;
        }

        public async Task<WishListOnlyIdDto> UpdateAsync(CreateWishListDto entity)
        {
            var mappedWishList = _mapper.Map<WishListDto>(entity);
            mappedWishList.WishListId = Guid.NewGuid();

            var res = await _wishListRepository.UpdateAsync(mappedWishList);

            var mappedResult = _mapper.Map<WishListOnlyIdDto>(res);

            return mappedResult;
        }

        public async Task RemoveAsync(CreateWishListDto entity)
        {
            var item = await GetAllAsync();
            var selecteItem = item.FirstOrDefault(x => x.PlayerId == entity.PlayerId && x.GameId == entity.GameId);
            if (selecteItem == null)
            {
                throw new NotFoundException("Selected WishList Game to be deleted Not Found");
            }


            var mappedResult = _mapper.Map<WishListDto>(selecteItem);

            await _wishListRepository.DeleteAsync(mappedResult);
        }
    }
}

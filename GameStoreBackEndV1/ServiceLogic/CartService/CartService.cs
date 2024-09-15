using AutoMapper;
using GameStoreBackEndV1.DataLogic.Cart;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;

namespace GameStoreBackEndV1.ServiceLogic.CartService
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<IList<DisplayCartDto>> GetAllAsync()
        {
            var result = await _cartRepository.GetAllAsync();
            var mappedResult = _mapper.Map<IList<DisplayCartDto>>(result);

            return mappedResult;
        }

        public async Task<DisplayCartDto> GetByIdAsync(Guid id)
        {
            var result = await _cartRepository.GetByIdAsync(id);
            var mappedResult = _mapper.Map<DisplayCartDto>(result);

            return mappedResult;
        }

        public async Task<DisplayCartDto> GetByPlayerIdAsync(Guid id)
        {
            var result = await _cartRepository.GetByPlayerIdAsync(id);
            var mappedResult = _mapper.Map<DisplayCartDto>(result);

            return mappedResult;
        }

        public async Task<CartDto> UpdateAsync(CreateAndUpdateCartDto entity)
        {
            var mappedCart = _mapper.Map<CartDto>(entity);
            mappedCart.CartId = Guid.NewGuid();

            var res = await _cartRepository.UpdateAsync(mappedCart);

            return res;
        }

        public async Task RemoveAsync(CreateAndUpdateCartDto entity)
        {
            var selectedPlayerCart = await _cartRepository.GetByPlayerIdAsync(entity.PlayerId);
            if (selectedPlayerCart == null)
            {
                throw new NotFoundException("Selected Cart to be deleted Not Found");
            }

            await _cartRepository.DeleteAsync(selectedPlayerCart);
        }
    }
}

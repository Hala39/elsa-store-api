using System.Collections.Generic;
using System.Threading.Tasks;
using ELSAPI.Dto;

namespace ELSAPI.Interfaces
{
    public interface IBasketRepo
    {
        Task<List<BasketItemDto>> GetBasketItemsForUser();
        Task<BasketItemDto> AddItemToBasket(CreateBasketItemDto item);
        Task<bool> RemoveItemFromBasket(int id);
        Task<bool> UpdateBasketItem(BasketItemDto item);
        
    }
}
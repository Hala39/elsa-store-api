using System.Collections.Generic;
using System.Threading.Tasks;
using ELSAPI.Dto;
using ELSAPI.Entities.OrderAggregate;

namespace ELSAPI.Interfaces
{
    public interface IOrderRepo
    {
         Task<OrderDto> PlaceOrder(CreateOrderDto orderDto);
         Task<List<OrderDto>> GetRecentOrders();
         Task<List<OrderDto>> GetPendingOrders();
         Task<bool> ConfirmOrder(int orderId);
         Task<bool> ClearRecentOrders();
        Task<bool> DeleteRecentOrder(int id);
    }
}
using OrderService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> CreateOrderAsync(int userId, int productId, int amount);
        Task<object> GetOrderDetailsAsync(int orderId);
    }
}

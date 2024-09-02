using Microsoft.EntityFrameworkCore;
using OrderService.Interfaces;
using OrderService.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrderService.Implements
{
    public class OrdersService : IOrdersService
    {
        private readonly OrderContext _context;
        private readonly HttpClient _httpClient;
        public OrdersService(OrderContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            return order;
        }
        public async Task<object> GetOrderDetailsAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return null;
            }
            var userName = await GetUserNameAsync(order.UserId);
            var productName = await GetProductNameAsync(order.ProductId);
            return new
            {
                UserName = userName,
                ProductName = productName
            };
        }
        private async Task<string> GetUserNameAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7188/api/users/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"User service returned {response.StatusCode}");
            }
            var user = await response.Content.ReadFromJsonAsync<UserDto>();
            return user?.Name;
        }
        private async Task<string> GetProductNameAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7197/api/products/{productId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Product service returned {response.StatusCode}");
            }
            var product = await response.Content.ReadFromJsonAsync<ProductDto>();
            return product?.Name;
        }
    }
}

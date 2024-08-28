using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using MainService.Models;
using MainService.Interfaces;

namespace MainService.Implements
{
    public class MainServices : IMainServices
    {
        private readonly HttpClient _httpClient;
        public MainServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync($"https://localhost:7188/api/users");
            response.EnsureSuccessStatusCode();
            var users = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
            return users;
        }
        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7188/api/users/{id}");
            response.EnsureSuccessStatusCode();
            var users = await response.Content.ReadFromJsonAsync<UserDto>();
            return users;
        }
        public async Task<UserDto> AddUserAsync(UserDto user)
        {
            user.Id = 0;
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7188/api/users", user);
            response.EnsureSuccessStatusCode();
            var createdUser = await response.Content.ReadFromJsonAsync<UserDto>();
            return createdUser;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync($"https://localhost:7197/api/products");
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
            return products;
        }
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7197/api/products/{id}");
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<ProductDto>();
            return products;
        }
        public async Task<ProductDto> AddProductAsync(ProductDto product)
        {
            product.Id = 0;
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7197/api/products", product);
            response.EnsureSuccessStatusCode();
            var createdProduct = await response.Content.ReadFromJsonAsync<ProductDto>();
            return createdProduct;
        }
        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var response = await _httpClient.GetAsync($"https://localhost:7138/api/orders");
            response.EnsureSuccessStatusCode();
            var orders = await response.Content.ReadFromJsonAsync<IEnumerable<OrderDto>>();
            return orders;
        }
        public async Task<OrderDto> CreateOrderAsync(int userId, int productId, int amount)
        {
            var order = new OrderDto
            {
                UserId = userId,
                ProductId = productId,
                Amount = amount,
                OrderDate = DateTime.UtcNow
            };
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7138/api/orders", order);
            response.EnsureSuccessStatusCode();
            var createdOrder = await response.Content.ReadFromJsonAsync<OrderDto>();
            return createdOrder;
        }
        public async Task<object> GetOrderDetailsAsync(int orderId)
        {
            var order = await GetOrderAsync(orderId);
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
        private async Task<OrderDto> GetOrderAsync(int orderId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7138/api/orders/{orderId}");
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadFromJsonAsync<OrderDto>();
            return order;
        }
        private async Task<string> GetUserNameAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7188/api/users/{userId}");
            response.EnsureSuccessStatusCode();
            var user = await response.Content.ReadFromJsonAsync<UserDto>();
            return user?.Name;
        }
        private async Task<string> GetProductNameAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7197/api/products/{productId}");
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadFromJsonAsync<ProductDto>();
            return product?.Name;
        }
    }
}

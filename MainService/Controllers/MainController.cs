using Microsoft.AspNetCore.Mvc;
using MainService.Implements;
using MainService.Interfaces;
using MainService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MainService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private readonly IMainServices _mainService;
        public MainController(IMainServices mainService)
        {
            _mainService = mainService;
        }
        // GET: api/users
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _mainService.GetAllUsersAsync();
            return Ok(users);
        }
        // GET: api/users/{id}
        [HttpGet("users/{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _mainService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        // POST: api/users
        [HttpPost("users")]
        public async Task<ActionResult<UserDto>> AddUser(UserDto user)
        {
            var addedUser= await _mainService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = addedUser.Id }, addedUser);
        }
        // GET: api/products
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _mainService.GetAllProductsAsync();
            return Ok(products);
        }
        // GET: api/products/{id}
        [HttpGet("products/{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _mainService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        // POST: api/products
        [HttpPost("products")]
        public async Task<ActionResult<ProductDto>> AddProduct(ProductDto product)
        {
            var addedProduct = await _mainService.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = addedProduct.Id }, addedProduct);
        }
        // GET: api/orders
        [HttpGet("order")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {
            var orders = await _mainService.GetAllOrdersAsync();
            return Ok(orders);
        }
        // POST: api/orders
        [HttpPost("order")]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromQuery] int userId, [FromQuery] int productId, [FromQuery] int amount)
        {
            var order = await _mainService.CreateOrderAsync(userId, productId, amount);
            return CreatedAtAction(nameof(GetAllOrders), new { id = order.Id }, order);
        }
        // GET: api/orders/{orderId}
        [HttpGet("orders/{orderId}")]
        public async Task<ActionResult<object>> GetOrderDetails(int orderId)
        {
            var orderDetails = await _mainService.GetOrderDetailsAsync(orderId);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }
    }
}

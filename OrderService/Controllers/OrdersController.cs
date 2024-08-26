using Microsoft.AspNetCore.Mvc;
using OrderService.Implements;
using OrderService.Interfaces;
using OrderService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;
        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromQuery] int userId, [FromQuery] int productId, [FromQuery] int amount)
        {
            var order = await _orderService.CreateOrderAsync(userId, productId, amount);
            return CreatedAtAction(nameof(GetAllOrders), new { id = order.Id }, order);
        }
        // GET: api/orders/{orderId}
        [HttpGet("{orderId}")]
        public async Task<ActionResult<object>> GetOrderDetails(int orderId)
        {
            var orderDetails = await _orderService.GetOrderDetailsAsync(orderId);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }
    }
}

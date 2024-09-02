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
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            var createdOrder = await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetAllOrders), new { id = order.Id }, order);
        }
        // GET: api/orders/{orderId}
        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrderById(int orderId)
        {
            var orderDetails = await _orderService.GetOrderByIdAsync(orderId);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }
        // GET: api/orders/details/{orderId}
        [HttpGet("details/{orderId}")]
        public async Task<ActionResult<Order>> GetOrderDetails(int orderId)
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

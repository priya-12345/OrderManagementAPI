using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Models;
using OrderManagementAPI.Repositories;

namespace OrderManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Authorize(Policy = "ViewOrdersPolicy")]
        public IActionResult GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "ViewOrdersPolicy")]
        public IActionResult GetOrder(int id)
        {
            var order = _orderRepository.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        [Authorize(Policy = "AddOrdersPolicy")]
        public IActionResult AddOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _orderRepository.AddOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "DeleteOrdersPolicy")]
        public IActionResult DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
            return NoContent();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using LaundryAPI.Services;
using LaundryAPI.Models;
using MongoDB.Driver;

namespace LaundryAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly MongoService _mongoService;

        public OrdersController(MongoService mongoService)
        {
            _mongoService = mongoService;
        }

        // GET all orders
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var orders = await _mongoService.Orders
                .Find(_ => true)
                .ToListAsync();

            return Ok(orders);
        }

        // CREATE order
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.created_at = DateTime.Now;
            order.order_status = "Pending";

            await _mongoService.Orders.InsertOneAsync(order);

            return Ok(order);
        }
        
        [HttpGet("{Order_id}")]
        public async Task<ActionResult<Order>> GetOrder(string Order_id)
        {
            var order = await _mongoService.Orders
                .Find(o => o.order_id == Order_id)
                .FirstOrDefaultAsync();

            if (order == null)
                return NotFound();

            return Ok(order);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(string id, Order updatedOrder)
        {
            var update = Builders<Order>.Update
                .Set(o => o.wash_type, updatedOrder.wash_type)
                .Set(o => o.total_amount, updatedOrder.total_amount)
                .Set(o => o.order_status, updatedOrder.order_status)
                .Set(o => o.note, updatedOrder.note);

            var result = await _mongoService.Orders.UpdateOneAsync(
                o => o.order_id == id,
                update
            );

            if (result.MatchedCount == 0)
                return NotFound();

            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            await _mongoService.Orders.DeleteOneAsync(o => o.order_id == id);

            return Ok("Deleted");
        }
    }
}
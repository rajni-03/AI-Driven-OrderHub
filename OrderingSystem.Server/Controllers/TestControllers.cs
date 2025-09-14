using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Shared.Models;

namespace OrderingSystem.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly List<Order> Orders = new();

        [HttpGet]
        public ActionResult<List<Order>> GetAll() => Orders;

        [HttpGet("{id}")]
        public ActionResult<Order> Get(string id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            return order is null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public ActionResult<Order> Create([FromBody] Order order)
        {
            order.Id = Guid.NewGuid().ToString();
            order.CreatedAt = DateTime.UtcNow;
            Orders.Add(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Order updated)
        {
            var idx = Orders.FindIndex(o => o.Id == id);
            if (idx == -1) return NotFound();
            updated.Id = id;
            Orders[idx] = updated;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var removed = Orders.RemoveAll(o => o.Id == id);
            return removed > 0 ? NoContent() : NotFound();
        }
    }
}
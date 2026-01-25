using Microsoft.AspNetCore.Mvc;
using OrderingSystemNew.Models;

[ApiController]
[Route("api/[controller]")]
[IgnoreAntiforgeryToken]
public class OrdersController : ControllerBase
{
    private static readonly List<Order> Orders = new();

    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        return Ok(Orders);
    }

    [HttpPost]
    public ActionResult<Order> CreateOrder([FromBody] Order order)
    {
        if (order == null)
        {
            return BadRequest("Order cannot be null");
        }

        if (string.IsNullOrWhiteSpace(order.CustomerName))
        {
            return BadRequest("Customer name is required");
        }

        if (order.Total <= 0)
        {
            return BadRequest("Total must be greater than 0");
        }

        order.Id = (Orders.Count + 1).ToString();
        order.Status = "New";
        order.CreatedAt = DateTime.UtcNow;

        Orders.Add(order);
        return Ok(order);
    }

    [HttpPut("{id}")]
    public ActionResult<Order> UpdateOrder(string id, [FromBody] Order order)
    {
        var existingOrder = Orders.FirstOrDefault(o => o.Id == id);
        if (existingOrder == null)
        {
            return NotFound($"Order with id {id} not found");
        }

        existingOrder.CustomerName = order.CustomerName;
        existingOrder.Total = order.Total;
        existingOrder.Quantity = order.Quantity;
        existingOrder.Status = order.Status;

        return Ok(existingOrder);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteOrder(string id)
    {
        var order = Orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            return NotFound($"Order with id {id} not found");
        }

        Orders.Remove(order);
        return Ok(new { message = $"Order {id} deleted successfully" });
    }

    [HttpPatch("{id}/ship")]
    public ActionResult<Order> MarkAsShipped(string id)
    {
        var order = Orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            return NotFound($"Order with id {id} not found");
        }

        order.Status = "Shipped";
        return Ok(order);
    }
}
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Shared;
using OrderingSystem.Shared.Models;

namespace OrderingSystem.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static List<Order> Orders = new List<Order>();

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(Orders);
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            order.Id = (Orders.Count + 1).ToString();
            Orders.Add(order);
            return Ok(order);
        }
    }
}

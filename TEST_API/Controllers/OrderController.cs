using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_API.Entities;
using TEST_API.Model;

namespace TEST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;
        public OrderController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.ToList();
            return Ok(orders);
            
        }
        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrder orderModel)
        {
            if(orderModel == null)
            {
                return BadRequest("Invalid order data!");
            }
            var order = new Order
            {
                ItemCode = orderModel.ItemCode,
                ItemName = orderModel.ItemName,
                ItemQty = orderModel.ItemQty,
                OrderDelivery = orderModel.OrderDelivery,
                OrderAddress = orderModel.OrderAddress,
                PhoneNumber = orderModel.PhoneNumber

            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Index), new { id = order.OrderId }, order);
        }
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}

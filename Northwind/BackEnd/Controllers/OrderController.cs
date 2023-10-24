using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        OrderModel Convertir(Order order) 
        {
            return new OrderModel
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,

            };
        }


        Order Convertir(OrderModel order)
        {
            return new Order
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,

            };
        }


        IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Order> orders = await _orderService.GetOrders();
            List<OrderModel> orderModels = new List<OrderModel>();
            foreach (var item in orders)
            {
                orderModels.Add(this.Convertir(item));
            }
            return Ok(orderModels);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Order order = await _orderService.GetById(id);
            return Ok(this.Convertir(order));
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderModel orderModel)
        {
            Order order = this.Convertir(orderModel);
            _orderService.Add(order);
            return Ok(Convertir(order));
        }

        // PUT api/<OrderController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderModel orderModel)
        {
            Order order = this.Convertir(orderModel);
            _orderService.Update(order);
            return Ok(Convertir(order));
        }

        // DELETE api/<OrderController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _orderService.Delete(id);
        }
    }
}

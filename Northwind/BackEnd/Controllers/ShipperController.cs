using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {

        public IShipperService _shipperService;

        private ShipperModel Convertir(Shipper shipper) 
        {
            return new ShipperModel
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
            };
        }


        private Shipper Convertir(ShipperModel shipper)
        {
            return new Shipper
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
            };
        }


        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        // GET: api/<ShipperController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Shipper> lista = _shipperService.GetShippersAsync().Result;
            List<ShipperModel> shippers = new List<ShipperModel>();
            foreach (var item in lista) 
            {
                shippers.Add(Convertir(item));

            }
            return Ok(shippers);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Shipper shipper = _shipperService.GetById(id);
            ShipperModel shipperModel = Convertir(shipper);
            return Ok(shipperModel);
        }

        // POST api/<ShipperController>
        [HttpPost]
        public IActionResult Post([FromBody] ShipperModel shipper)
        {
            Shipper entity = Convertir(shipper);
            _shipperService.AddShipper(entity);
            return Ok(Convertir(entity));
        }

        // PUT api/<ShipperController>/5
        [HttpPut]
        public IActionResult Put([FromBody] ShipperModel shipper)
        {
            Shipper entity = Convertir(shipper);
            _shipperService.UpdateShipper(entity);
            return Ok(Convertir(entity));
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Shipper shipper = new Shipper
            {
                ShipperId = id
            };

            _shipperService.DeleteShipper(shipper);
            return Ok();
        }
    }
}

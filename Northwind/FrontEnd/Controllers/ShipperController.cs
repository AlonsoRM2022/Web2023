using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ShipperController : Controller
    {

        IShipperHelper shipperHelper;

        public ShipperController(IShipperHelper _shipperHelper)
        {
            shipperHelper = _shipperHelper;
        }

        // GET: ShipperController
        public ActionResult Index()
        {
            //ShipperHelper shipperHelper = new ShipperHelper();
            List<ShipperViewModel> shippers = shipperHelper.GetAll();
            return View(shippers);
        }

        // GET: ShipperController/Details/5
        public ActionResult Details(int id)
        {
            ShipperViewModel shipper = shipperHelper.GetById(id);
            return View(shipper);
        }

        // GET: ShipperController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipperViewModel shipper)
        {
            try
            {
                shipperHelper.AddShipper(shipper);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShipperController/Edit/5
        public ActionResult Edit(int id)
        {
            ShipperViewModel shipper = shipperHelper.GetById(id);
            return View(shipper);
        }

        // POST: ShipperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShipperViewModel shipper)
        {
            try
            {
                ShipperViewModel shipperViewModel = shipperHelper.EditShipper(shipper);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShipperController/Delete/5
        public ActionResult Delete(int id)
        {
            ShipperViewModel shipper = shipperHelper.GetById(id);
            return View(shipper);
        }

        // POST: ShipperController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ShipperViewModel shipper)
        {
            try
            {
                shipperHelper.DeleteShipper(shipper.ShipperId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

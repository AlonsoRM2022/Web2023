using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class OrderController : Controller
    {

        IOrderHelper orderHelper;
        IShipperHelper shipperHelper;
        ICustomerHelper customerHelper;
        IEmployeeHelper employeeHelper;

        public OrderController(IOrderHelper OrderHelper,
                               IShipperHelper ShipperHelper,
                               ICustomerHelper CustomerHelper,
                               IEmployeeHelper EmployeeHelper)
        {
            orderHelper = OrderHelper;
            shipperHelper = ShipperHelper;
            customerHelper = CustomerHelper;
            employeeHelper = EmployeeHelper;

        }


        // GET: OrderController
        public ActionResult Index()
        {
            List<OrderViewModel> orders = orderHelper.GetAll();
            return View(orders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            OrderViewModel order = orderHelper.GetById(id);
            return View(order);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            OrderViewModel order = new OrderViewModel();
            order.Customers = customerHelper.GetAll();
           // order.Employees = employeeHelper.GetAll();
            return View(order);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel order)
        {
            try
            {
                orderHelper.AddOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            OrderViewModel order = orderHelper.GetById(id);
            order.Customers = customerHelper.GetAll();
            // order.Employees = employeeHelper.GetAll();
            return View(order);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderViewModel order)
        {
            try
            {
                orderHelper.EditOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            OrderViewModel order = orderHelper.GetById(id);
            return View(order);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OrderViewModel order)
        {
            try
            {
                orderHelper.DeleteOrder(order.OrderId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

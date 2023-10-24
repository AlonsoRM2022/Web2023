using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IShipperDAL _shipperDAL { get; }
        public ICustomerDAL _customerDAL { get; }
        public IEmployeeDAL _employeeDAL { get; }
        public IOrderDAL _orderDAL { get; }

        private readonly NorthWindContext _context;

        public UnidadDeTrabajo(NorthWindContext context, 
            IShipperDAL shipperDAL,
            ICustomerDAL customerDAL, 
            IEmployeeDAL employeeDAL,
            IOrderDAL orderDAL)
        {
            _context = context;
            _shipperDAL = shipperDAL;
            _customerDAL = customerDAL;
            _employeeDAL = employeeDAL;
            _orderDAL = orderDAL;

        }

        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

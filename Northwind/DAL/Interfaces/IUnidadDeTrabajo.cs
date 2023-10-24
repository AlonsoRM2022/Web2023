using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {

        IShipperDAL _shipperDAL { get; }
        ICustomerDAL _customerDAL { get; }
        IEmployeeDAL _employeeDAL { get; }
        IOrderDAL _orderDAL { get; }
        bool Complete();
    }
}
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CustomerService : ICustomerService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public CustomerService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            IEnumerable<Customer> customers = new List<Customer>();
            customers = await _unidadDeTrabajo._customerDAL.GetAll();
            return customers;
        }
    }
}

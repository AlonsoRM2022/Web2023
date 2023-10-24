using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public EmployeeService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            IEnumerable<Employee> employees = new List<Employee>();
            employees = await _unidadDeTrabajo._employeeDAL.GetAll();
            return employees;
        }
    }
}

using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class EmployeeHelper : IEmployeeHelper
    {

        IServiceRepository _repository;

        public EmployeeHelper(IServiceRepository service)
        {
            _repository = service;
        }

        public List<EmployeeViewModel> GetAll()
        {
            List<EmployeeViewModel> lista = new List<EmployeeViewModel>();
            HttpResponseMessage response = _repository.GetResponse("api/employee");
            if (response != null) 
            {
                var content = response.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(content);
            }
            return lista;
        }
    }
}

using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CustomerHelper : ICustomerHelper
    {

        IServiceRepository _repository;

        public CustomerHelper(IServiceRepository service)
        {
            _repository = service;
        }

        public List<CustomerViewModel> GetAll()
        {
            List<CustomerViewModel> lista = new List<CustomerViewModel>();
            HttpResponseMessage response = _repository.GetResponse("api/customer");
            if (response != null) 
            {
                var content = response.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CustomerViewModel>>(content);
            }

            return lista;
        }
    }
}

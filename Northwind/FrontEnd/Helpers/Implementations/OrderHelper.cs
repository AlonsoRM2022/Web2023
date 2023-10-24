using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class OrderHelper : IOrderHelper
    {

        IServiceRepository _repository;

        public OrderHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public OrderViewModel AddOrder(OrderViewModel OrderViewModel)
        {
            OrderViewModel order = new OrderViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/order", OrderViewModel);
            if (responseMessage != null) 
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<OrderViewModel>(content);
            }
            return order;
        }

        public void DeleteOrder(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/order/" + id.ToString());
            if (responseMessage != null) 
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public OrderViewModel EditOrder(OrderViewModel OrderViewModel)
        {
            OrderViewModel order = new OrderViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/order", OrderViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<OrderViewModel>(content);
            }
            return order;
        }

        public List<OrderViewModel> GetAll()
        {
            List<OrderViewModel> lista = new List<OrderViewModel>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Order");
            if (responseMessage != null) 
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<OrderViewModel>>(content);
            }
            return lista;
        }

        public OrderViewModel GetById(int id)
        {
            OrderViewModel Order = new OrderViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Order/" + id.ToString());
            if (responseMessage != null) 
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                Order = JsonConvert.DeserializeObject<OrderViewModel>(content);
            }
            return Order;
        }
    }
}

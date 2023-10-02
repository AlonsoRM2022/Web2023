using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ShipperHelper
    {
        ServiceRepository _repository;

        public ShipperHelper()
        {
            _repository = new ServiceRepository();
        }

        public List<ShipperViewModel> GetAll()
        {
            List<ShipperViewModel> lista = new List<ShipperViewModel>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Shipper");
            if (responseMessage != null) 
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ShipperViewModel>>(content);
            }

            return lista;
        }
    }
}

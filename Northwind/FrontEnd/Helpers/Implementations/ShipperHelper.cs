using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ShipperHelper: IShipperHelper
    {
        IServiceRepository _repository;

        public ShipperHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public ShipperViewModel AddShipper(ShipperViewModel shipperViewModel)
        {
            ShipperViewModel shipper = new ShipperViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Shipper",shipperViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);
            }
            return shipper;
        }

        public void DeleteShipper(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Shipper/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public ShipperViewModel EditShipper(ShipperViewModel shipperViewModel)
        {
            ShipperViewModel shipper = new ShipperViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Shipper", shipperViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);
            }
            return shipper;
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

        public ShipperViewModel GetById(int id)
        {
            ShipperViewModel shipper = new ShipperViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Shipper/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);
            }
            return shipper;
        }
    }
}

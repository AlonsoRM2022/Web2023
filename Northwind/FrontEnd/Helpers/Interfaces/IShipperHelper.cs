using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IShipperHelper
    {
        List<ShipperViewModel> GetAll();
        ShipperViewModel GetById(int id);
        ShipperViewModel AddShipper(ShipperViewModel shipperViewModel);
        ShipperViewModel EditShipper(ShipperViewModel shipperViewModel);
        void DeleteShipper(int id);
    }
}

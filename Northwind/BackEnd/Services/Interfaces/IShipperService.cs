using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IShipperService
    {
        Task<IEnumerable<Shipper>> GetShippersAsync();
        Shipper GetById(int id);
        bool AddShipper(Shipper shipper);
        bool UpdateShipper(Shipper shipper);
        bool DeleteShipper(Shipper shipper);

    }
}

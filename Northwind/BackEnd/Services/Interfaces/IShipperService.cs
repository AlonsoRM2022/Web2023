using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IShipperService
    {
        Task<IEnumerable<Shipper>> GetShippersAsync();

    }
}

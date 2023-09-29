using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ShipperService : IShipperService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ShipperService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<IEnumerable<Shipper>> GetShippersAsync()
        {
            IEnumerable<Shipper> shippers;
            shippers = await _unidadDeTrabajo._shipperDAL.GetAll();
            return shippers;
        }
    }
}

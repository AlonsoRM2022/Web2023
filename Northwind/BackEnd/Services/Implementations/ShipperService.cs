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

        public bool AddShipper(Shipper shipper)
        {
            bool resultado = _unidadDeTrabajo._shipperDAL.Add(shipper);
            _unidadDeTrabajo.Complete();
            return resultado;
        }

        public bool DeleteShipper(Shipper shipper)
        {
            bool resultado = _unidadDeTrabajo._shipperDAL.Remove(shipper);
            _unidadDeTrabajo.Complete();
            return resultado;
        }

        public Shipper GetById(int id)
        {
            Shipper shipper;
            shipper = _unidadDeTrabajo._shipperDAL.Get(id);
            return shipper;
        }

        public async Task<IEnumerable<Shipper>> GetShippersAsync()
        {
            IEnumerable<Shipper> shippers;
            shippers = await _unidadDeTrabajo._shipperDAL.GetAll();
            return shippers;
        }

        public bool UpdateShipper(Shipper shipper)
        {
            bool resultado = _unidadDeTrabajo._shipperDAL.Update(shipper);
            _unidadDeTrabajo.Complete();
            return resultado;
        }
    }
}

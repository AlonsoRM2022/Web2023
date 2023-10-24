using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class OrderService : IOrderService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;

        public OrderService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public Task<bool> Add(Order order)
        {
            try
            {
                _unidadDeTrabajo._orderDAL.Add(order);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false); ;
            }

            
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                Order order = new Order { OrderId = id };
                _unidadDeTrabajo._orderDAL.Remove(order);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }

            
        }

        public async Task<Order> GetById(int id)
        {
            Order order = _unidadDeTrabajo._orderDAL.Get(id);
            return order;
        }



        public async Task<IEnumerable<Order>> GetOrders()
        {
            IEnumerable<Order> orders = await _unidadDeTrabajo._orderDAL.GetAll();
            return orders;
        }



        public Task<bool> Update(Order order)
        {
            try
            {
                _unidadDeTrabajo._orderDAL.Update(order);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }

            
        }
    }
}

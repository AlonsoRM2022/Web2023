using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<bool> Add(Order order);
        Task<bool> Delete(int id);
        Task<bool> Update(Order order);
        Task<Order> GetById(int id);
    }
}

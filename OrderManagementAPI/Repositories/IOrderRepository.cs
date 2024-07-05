using OrderManagementAPI.Models;

namespace OrderManagementAPI.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order? GetOrder(int id);
        void AddOrder(Order order);
        void DeleteOrder(int id);
    }
}

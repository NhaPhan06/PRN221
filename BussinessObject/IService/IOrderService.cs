using BussinessObject.CartService;
using DataAccess.DataAccess;

namespace BussinessObject.IService;

public interface IOrderService
{
    Task<List<Order>> GetAllOrder();
    Task<List<Order>> GetOrderOfCustomer(Guid customerId);
    Task OrderPizza(Guid customer, List<Cart> carts);
    Task CancleOrder(Guid id);
}
using DataAccess.DataAccess;

namespace BussinessObject.IService;

public interface IOrderService
{
    Task<List<Order>> GetAllOrder();
    Task<List<Order>> GetOrderOfCustomer(Guid customerId);
    Task OrderPizza();
}
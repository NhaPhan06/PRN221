using DataAccess.DataAccess;
using DataAccess.IRepository.IGeneric;

namespace DataAccess.IRepository;

public interface IOrderRepo : IGeneric<Order>
{
    Task<List<Order>> GetAllOrderOfCustomer(Guid id);
    
    Task<List<Order>> GetAllOrderDesc();
}
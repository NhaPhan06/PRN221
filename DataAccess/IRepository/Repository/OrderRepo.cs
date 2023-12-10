using DataAccess.DataAccess;
using DataAccess.DataAccess.Repository.Generic;
using DataAccess.IRepository;

namespace DataAccess.Repository;

public class OrderRepo : Generic<Order>, IOrderRepo
{
    public OrderRepo(PizzaStoreContext context) : base(context)
    {
    }

    public async Task<List<Order>> GetAllOrderOfCustomer(Guid id)
    {
        return _context.Orders.Where(order => order.CustomerId == id).ToList();
    }
}
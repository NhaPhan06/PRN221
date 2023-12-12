using DataAccess.DataAccess;
using DataAccess.DataAccess.Repository.Generic;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

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

    public Task<List<Order>> GetAllOrderDesc()
    {
        return _context.Orders.Include(o => o.Customer).OrderByDescending(o => o.OrderDate).ToListAsync();
    }
}
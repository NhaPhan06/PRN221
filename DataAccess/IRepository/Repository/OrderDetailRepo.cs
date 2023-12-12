using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.IRepository.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class OrderDetailRepo : Generic<OrderDetail>, IOrderDetailRepo
{
    public OrderDetailRepo(PizzaStoreContext context) : base(context)
    {
    }

    public List<OrderDetail> getOrderDetails(Guid id)
    {
        return _context.OrderDetails.Include(o => o.Product).Where(o => o.OrderId == id).ToList();
    }
}
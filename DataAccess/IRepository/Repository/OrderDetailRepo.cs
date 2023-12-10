using DataAccess.DataAccess;
using DataAccess.DataAccess.Repository.Generic;
using DataAccess.IRepository;

namespace DataAccess.Repository;

public class OrderDetailRepo : Generic<OrderDetail>, IOrderDetailRepo
{
    public OrderDetailRepo(PizzaStoreContext context) : base(context)
    {
    }
}
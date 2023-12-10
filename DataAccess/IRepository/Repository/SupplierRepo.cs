using DataAccess.DataAccess;
using DataAccess.DataAccess.Repository.Generic;
using DataAccess.IRepository;

namespace DataAccess.Repository;

public class SupplierRepo : Generic<Supplier>, ISupplierRepo
{
    public SupplierRepo(PizzaStoreContext context) : base(context)
    {
    }
}
using DataAccess.DataAccess;
using DataAccess.DataAccess.Repository.Generic;
using DataAccess.IRepository;

namespace DataAccess.Repository;

public class CustomerRepo : Generic<Customer>, ICustomerRepo
{
    public CustomerRepo(PizzaStoreContext context) : base(context)
    {
    }
}
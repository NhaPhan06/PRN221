using DataAccess.DataAccess;
using DataAccess.DataAccess.Repository.Generic;
using DataAccess.IRepository;

namespace DataAccess.Repository;

public class CustomerRepo : Generic<Customer>, ICustomerRepo
{
    public CustomerRepo(PizzaStoreContext context) : base(context)
    {
    }

    public Customer Login(string username, string pass)
    {
        var acc = _context.Customers.FirstOrDefault(a => a.UserName == username && a.Password == pass);
        if (acc != null)
        {
            return acc;
        }

        return null;
    }
}
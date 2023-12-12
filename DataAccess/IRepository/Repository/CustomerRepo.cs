using DataAccess.DataAccess;
using DataAccess.IRepository.Repository.Generic;

namespace DataAccess.IRepository.Repository;

public class CustomerRepo : Generic<Customer>, ICustomerRepo
{
    public CustomerRepo(PizzaStoreContext context) : base(context)
    {
    }

    public Customer Login(string username, string pass)
    {
        var acc = _context.Customers.FirstOrDefault(a => a.UserName == username && a.Password == pass);
        if (acc != null) return acc;
        return null;
    }
}
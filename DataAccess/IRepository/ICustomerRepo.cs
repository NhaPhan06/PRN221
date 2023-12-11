using DataAccess.DataAccess;
using DataAccess.IRepository.IGeneric;

namespace DataAccess.IRepository;

public interface ICustomerRepo: IGeneric<Customer>
{
    public Customer Login(string username, string pass);
}
using DataAccess.DataAccess;

namespace BussinessObject.IService;

public interface ICustomerService
{
    Task Register(Customer customer);
    Task<Customer> Login(string email, string pass);
}
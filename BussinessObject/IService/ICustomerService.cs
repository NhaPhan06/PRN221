using DataAccess.DataAccess;

namespace BussinessObject.IService;

public interface ICustomerService
{
    Task Register(Customer customer);
}
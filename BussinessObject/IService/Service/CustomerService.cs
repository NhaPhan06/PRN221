using DataAccess.DataAccess;
using DataAccess.IRepository.IUnitOfWork;

namespace BussinessObject.IService.Service;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Register(Customer customer)
    {
        customer.Status = "ACTIVE";
        _unitOfWork.Customer.Add(customer);
    }

    public async Task<Customer> Login(string email, string pass)
    {
        var acc = _unitOfWork.Customer.Login(email, pass);
        if (acc != null) return acc;
        return null;
    }
}
using BussinessObject.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.IRepository.IUnitOfWork;

namespace BussinessObject.Service;

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
}
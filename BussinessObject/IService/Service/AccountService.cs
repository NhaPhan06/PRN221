using AutoMapper;
using BussinessObject.DTOS;
using BussinessObject.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.IUnitOfWork;

namespace BussinessObject.Service;

public class AccountService :IAccountService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Account> Login( String username, String pass)
    {
        var acc = await _unitOfWork.Account.Login(username, pass);
        return acc;
    }

    public void CreateAccountCustomer(CustomerDTOS customerDtos)
    {
        var customer = _mapper.Map<Customer>(customerDtos);
        _unitOfWork.Customer.Add(customer);
        _unitOfWork.Save();
    }
    
    
}
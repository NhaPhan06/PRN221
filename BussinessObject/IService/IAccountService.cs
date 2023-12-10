using BussinessObject.DTOS;
using DataAccess.DataAccess;

namespace BussinessObject.IService;

public interface IAccountService
{
    public Task<Account> Login(String username, String pass);
    public void CreateAccountCustomer(CustomerDTOS customerDtos);
    
    
}
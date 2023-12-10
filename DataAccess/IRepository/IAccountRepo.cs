using DataAccess.DataAccess;
using DataAccess.IRepository.IGeneric;

namespace DataAccess.IRepository;

public interface IAccountRepo : IGeneric<Account>
{
    Task<Account> Login(String username, String pass);
}
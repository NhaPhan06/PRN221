using DataAccess.DataAccess;
using DataAccess.DataAccess.Repository.Generic;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class AccountRepo : Generic<Account> , IAccountRepo
{
    public AccountRepo(PizzaStoreContext context) : base(context)
    {
    }

    public async Task<Account> Login(string username, string pass)
    {
        return await _context.Accounts.FirstAsync(a => a.UserName == username && a.Password == pass);
    }
}
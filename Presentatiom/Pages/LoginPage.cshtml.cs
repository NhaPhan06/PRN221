using BussinessObject.IService;
using DataAccess.DataAccess;
using DataAccess.DataAccess.Enum;
using DataAccess.IRepository.IUnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentatiom.Pages;

public class LoginPage : PageModel
{

    private IUnitOfWork _unitOfWork;
    private IAccountService _accountService;

    public LoginPage(IUnitOfWork unitOfWork, IAccountService accountService)
    {
        _unitOfWork = unitOfWork;
        _accountService = accountService;
    }


    [BindProperty] public String UserName { get; set; }
    [BindProperty] public String Passwork { get; set; }
    
    public async Task<IActionResult> OnPostLogin()
    {
        var acc = await _accountService.Login(UserName, Passwork);
        if (acc.Type.ToString().Equals(AccountType.Customer.ToString()))
        {
            return RedirectToPage("/MenuPage");
        }
        else if (acc.Type.ToString().Equals(AccountType.Staff.ToString()))
        {
            return RedirectToPage("/ProductPage");
        }
        else
        {
            return Page();
        }
    }

}
using BussinessObject.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation_Razor.Pages;

public class LoginPage : PageModel
{
    private readonly ICustomerService _customerService;

    public LoginPage(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [BindProperty] public string userName { get; set; }

    [BindProperty] public string password { get; set; }

    public void OnPostLogin()
    {
    }
}
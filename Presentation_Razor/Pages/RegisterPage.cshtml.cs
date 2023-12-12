using BussinessObject.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation_Razor.Pages;

public class RegisterPageModel : PageModel
{
    private readonly ICustomerService _customerService;

    public RegisterPageModel(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [BindProperty] public Customer Customer { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        _customerService.Register(Customer);
        return RedirectToPage("/HomePage");
    }
}
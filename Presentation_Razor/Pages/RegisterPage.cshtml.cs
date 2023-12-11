using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessObject.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;
using DataAccess.DataAccess;

namespace Presentation_Razor.Pages
{
    public class RegisterPageModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public RegisterPageModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _customerService.Register(Customer);
            return RedirectToPage("/HomePage");
        }
    }
}
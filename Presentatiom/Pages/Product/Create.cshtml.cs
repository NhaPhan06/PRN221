using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.DataAccess;

namespace Presentatiom.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly DataAccess.DataAccess.PizzaStoreContext _context;

        public CreateModel(DataAccess.DataAccess.PizzaStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description");
        ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Address");
            return Page();
        }

        [BindProperty]
        public DataAccess.DataAccess.Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

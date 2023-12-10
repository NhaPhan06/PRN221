using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataAccess;

namespace Presentatiom.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.DataAccess.PizzaStoreContext _context;

        public DetailsModel(DataAccess.DataAccess.PizzaStoreContext context)
        {
            _context = context;
        }

      public DataAccess.DataAccess.Product Product { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }
    }
}

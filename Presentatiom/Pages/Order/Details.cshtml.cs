using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataAccess;

namespace Presentatiom.Pages.Order
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.DataAccess.PizzaStoreContext _context;

        public DetailsModel(DataAccess.DataAccess.PizzaStoreContext context)
        {
            _context = context;
        }

      public DataAccess.DataAccess.Order Order { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            return Page();
        }
    }
}

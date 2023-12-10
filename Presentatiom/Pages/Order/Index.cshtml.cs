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
    public class IndexModel : PageModel
    {
        private readonly DataAccess.DataAccess.PizzaStoreContext _context;

        public IndexModel(DataAccess.DataAccess.PizzaStoreContext context)
        {
            _context = context;
        }

        public IList<DataAccess.DataAccess.Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders
                .Include(o => o.Customer).ToListAsync();
            }
        }
    }
}

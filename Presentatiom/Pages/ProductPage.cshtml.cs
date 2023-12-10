using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.IRepository.IUnitOfWork;

namespace Presentatiom.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly  IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<DataAccess.DataAccess.Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            List<DataAccess.DataAccess.Product> products = new List<DataAccess.DataAccess.Product>();
            products = _unitOfWork.Product.GetAll().ToList();
            if (products.Count != 0)
            {
                Product = products;
            }
        }
    }
}

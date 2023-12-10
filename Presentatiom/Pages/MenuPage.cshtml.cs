using BussinessObject.DTOS;
using BussinessObject.IService;
using BussinessObject.Service;
using DataAccess.IRepository.IUnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentatiom.Pages;

public class MenuPage : PageModel
{
    private IProductService _productService;
    private IUnitOfWork _unitOfWork;

    public MenuPage(IProductService productService, IUnitOfWork unitOfWork)
    {
        _productService = productService;
        _unitOfWork = unitOfWork;
    }

    [BindProperty] public String Name { get; set; } = default!;
    

    public IList<Menu> Menu { get;set; } = default!;

    public async Task OnGetAsync()
    {
            Menu = await _productService.GetMenu();
    }

    public async Task<IActionResult> OnGetSearch()
    {
        Menu = await _productService.Search(Name);
        return Page();
    }
}
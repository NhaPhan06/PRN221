using BussinessObject.CartService;
using BussinessObject.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DefaultNamespace;

public class HomePage : PageModel
{
    public readonly IProductService _productService;

    public HomePage(IProductService productService)
    {
        _productService = productService;
    }

    public IList<Product> Product { get; set; } = default!;
    public IList<Cart> Carts { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Console.WriteLine("new");
        Product = await _productService.GetProduct();

        var jsoncart = HttpContext.Session.GetString("cart");

        if (jsoncart != null) Carts = JsonConvert.DeserializeObject<List<Cart>>(jsoncart);
    }

    public async Task<IActionResult> OnPostAdd(Guid Id)
    {
        var check = false;
        var cart = new Cart();
        var product = await _productService.GetByID(Id);

        var json = HttpContext.Session.GetString("cart");

        if (json != null) Carts = JsonConvert.DeserializeObject<List<Cart>>(json);
        
        if (Carts == null)
        {
            Carts = new List<Cart>();
            cart.Id = product.Id;
            cart.Price = product.UnitPrice.Value;
            cart.Quantity = 1;
            cart.ProductName = product.Name;
            cart.Image = product.Image;
            Carts.Add(cart);
        }
        else
        {
            foreach (var c in Carts)
                if (c.Id == product.Id)
                {
                    check = true;
                    c.Quantity += 1;
                    c.Price += product.UnitPrice.Value;
                }

            if (check == false)
            {
                cart.Id = product.Id;
                cart.Price = product.UnitPrice.Value;
                cart.Quantity = 1;
                cart.ProductName = product.Name;
                cart.Image = product.Image;
                Carts.Add(cart);
            }
        }
        
        var jsoncart = JsonConvert.SerializeObject(Carts);
        HttpContext.Session.SetString("cart", jsoncart);
        return RedirectToPage("/HomePage");
    }

    public async Task<IActionResult> OnPostBuy()
    {
        var json = HttpContext.Session.GetString("cart");
        if (json != null) Carts = JsonConvert.DeserializeObject<List<Cart>>(json);
        foreach (var c in Carts)
        {
            
        }
        return RedirectToPage("/HomePage");
    }
}
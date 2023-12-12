using BussinessObject.CartService;
using BussinessObject.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Presentation_Razor.Pages;

public class CartPage : PageModel
{
    private readonly IOrderService _orderService;

    public CartPage(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    public IList<Cart> Carts { get; set; } = default!; 
    
    public void OnGet()
    {
        var jsoncart = HttpContext.Session.GetString("cart");

        if (jsoncart != null) Carts = JsonConvert.DeserializeObject<List<Cart>>(jsoncart);
    }

    public void OnPost()
    {
        
    }
}
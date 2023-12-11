using System.Windows;
using BussinessObject.IService;
using BussinessObject.Service;

namespace WPF_Presentation;

public partial class LoginWindow : Window
{
    ICustomerService _customerService;
     IOrderService _orderService;
     IProductService _productService;
     private IOrderDetailService _orderDetailService;
    public LoginWindow(ICustomerService customerService, IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
        _orderService = orderService;
        _productService = productService;
        _customerService = customerService;
        InitializeComponent();
    }

    private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void BtnClose_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private async void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        var username = txtUser.Text;
        var pass = txtPass.Password;
        var login = await _customerService.Login(username, pass);
        if (login != null)
        {
            CustomerWindow window = new CustomerWindow(login, _customerService , _productService , _orderService, _orderDetailService);
            window.Show();
            Close();
        }
        Error.Content = "LOGIN FAIL !";
    }
}
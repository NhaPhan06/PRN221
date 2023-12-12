using System.Windows;
using BussinessObject.IService;

namespace WPF_Presentation;

public partial class LoginWindow : Window
{
    private readonly ICustomerService _customerService;
    private readonly IOrderDetailService _orderDetailService;
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;

    public LoginWindow(ICustomerService customerService, IProductService productService, IOrderService orderService,
        IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
        _orderService = orderService;
        _productService = productService;
        _customerService = customerService;
        InitializeComponent();
    }

    private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void BtnClose_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private async void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        var username = txtUser.Text;
        var pass = txtPass.Password;
        if (username == "admin" && pass == "1")
        {
            var window =
                new ManagermentWindow(_customerService, _productService, _orderService, _orderDetailService);
            window.Show();
            Close();
        }

        var login = await _customerService.Login(username, pass);
        if (login != null)
        {
            var window = new CustomerWindow(login, _customerService, _productService, _orderService,
                _orderDetailService);
            window.Show();
            Close();
        }

        Error.Content = "LOGIN FAIL !";
    }
}
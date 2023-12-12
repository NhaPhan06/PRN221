using System.Windows;
using BussinessObject.IService;
using DataAccess.DataAccess;

namespace WPF_Presentation;

public partial class CustomerWindow : Window
{
    private readonly Customer _customer;

    private readonly ICustomerService _customerService;
    private readonly IOrderDetailService _orderDetailService;
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;

    public CustomerWindow(Customer customer, ICustomerService customerService, IProductService productService,
        IOrderService orderService, IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
        _orderService = orderService;
        _productService = productService;
        _customerService = customerService;
        _customer = customer;
        InitializeComponent();
    }

    private void OrderWindow_Click(object sender, RoutedEventArgs routedEventArgs)
    {
        var window = new OrderHistoryWindow(_customer, _customerService, _productService, _orderService,
            _orderDetailService);
        window.Show();
        Close();
    }

    private void ShoppingWindow_Click(object sender, RoutedEventArgs routedEventArgs)
    {
        var window = new StorePizzaWindow(_customer, _customerService, _productService, _orderService,
            _orderDetailService);
        window.Show();
        Close();
    }

    private void BtnClose_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void BtnBack_OnClick(object sender, RoutedEventArgs e)
    {
        LoginWindow window = new LoginWindow(_customerService, _productService, _orderService, _orderDetailService);
        window.Show();
        Close();
    }
}
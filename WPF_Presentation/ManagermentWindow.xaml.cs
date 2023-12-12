using System.Windows;
using BussinessObject.IService;

namespace WPF_Presentation;

public partial class ManagermentWindow : Window
{
    ICustomerService _customerService;
    IOrderService _orderService;
    IProductService _productService;
    private IOrderDetailService _orderDetailService;
    
    public ManagermentWindow(ICustomerService customerService, IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
        _orderService = orderService;
        _productService = productService;
        _customerService = customerService;
        InitializeComponent();
    }
    private void OrderWindow_Click(object sender, RoutedEventArgs routedEventArgs)
    {
        OrderManagerWindow window = new OrderManagerWindow(_customerService, _productService, _orderService, _orderDetailService);
        window.Show();
        Close();
    }

    private void ProductWindow_Click(object sender, RoutedEventArgs routedEventArgs)
    {

    }

    private void BtnClose_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
    
}
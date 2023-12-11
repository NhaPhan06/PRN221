using System;
using System.Windows;
using System.Windows.Input;
using BussinessObject.IService;
using DataAccess.DataAccess;

namespace WPF_Presentation;

public partial class CustomerWindow : Window
{
    
    ICustomerService _customerService;
    IOrderService _orderService;
    IProductService _productService;
    private IOrderDetailService _orderDetailService;
    private Customer _customer;
    public CustomerWindow(Customer customer, ICustomerService customerService, IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService)
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
        OrderHistoryWindow window = new OrderHistoryWindow(_customer, _customerService, _productService, _orderService, _orderDetailService);
        window.Show();
        Close();
    }

    private void ShoppingWindow_Click(object sender, RoutedEventArgs routedEventArgs)
    {
        StorePizzaWindow window = new StorePizzaWindow(_customer, _customerService, _productService, _orderService, _orderDetailService);
        window.Show();
        Close();
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
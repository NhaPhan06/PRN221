using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using BussinessObject.IService;
using DataAccess.DataAccess;

namespace WPF_Presentation;

public partial class OrderHistoryWindow : Window
{
    
    ICustomerService _customerService;
    IOrderService _orderService;
    IProductService _productService;
    IOrderDetailService _orderDetailService;
    private Customer _customer;
    
    public OrderHistoryWindow(Customer customer, ICustomerService customerService, IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
        _orderService = orderService;
        _productService = productService;
        _customerService = customerService;
        _customer = customer;
        InitializeComponent();
    }
    
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var list = await _orderService.GetOrderOfCustomer(_customer.Id);
        OrderListView.ItemsSource = list;
    }

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowInteropHelper helper = new WindowInteropHelper(this);
        SendMessage(helper.Handle, 161, 2, 0);
    }

    private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
    {
        this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void btnMaximize_Click(object sender, RoutedEventArgs e)
    {
        if (this.WindowState == WindowState.Normal)
            this.WindowState = WindowState.Maximized;
        else this.WindowState = WindowState.Normal;
    }

    private async void btnDetail_Click(object sender, RoutedEventArgs e)
    {
        Order o = OrderListView.SelectedItem as Order;
        if (o != null)
        {
            var orderDetail = await _orderDetailService.GetDetailOfOrder(o.Id);
            DetailListView.ItemsSource = orderDetail;
            decimal totalPrice = 0;
            foreach (var d in orderDetail)
            {
                totalPrice += d.UnitPrice;
            }
            lbTotalPrice.Content = totalPrice.ToString();
        }
    }

    private void BtnBack_Click(object sender, RoutedEventArgs e)
    {
        CustomerWindow window = new CustomerWindow(_customer, _customerService, _productService, _orderService, _orderDetailService);
        window.Show();
        Close();
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        Order o = OrderListView.SelectedItem as Order;
        if (o.Status == "Prepare")
        {
            _orderService.CancleOrder(o.Id);
            DetailListView.ItemsSource = null;
        }
        Window_Loaded(sender,e);
    }
}
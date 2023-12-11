using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using BussinessObject.CartService;
using BussinessObject.IService;
using BussinessObject.Service;
using DataAccess.DataAccess;

namespace WPF_Presentation;

public partial class StorePizzaWindow : Window
{
    ICustomerService _customerService;
    IOrderService _orderService;
    IProductService _productService;
    IOrderDetailService _orderDetailService;
    private Customer _customer;
    
    public StorePizzaWindow(Customer customer, ICustomerService customerService, IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
        _orderService = orderService;
        _productService = productService;
        _customerService = customerService;
        _customer = customer;
        InitializeComponent();
    }
    
    private List<Cart> Carts = new List<Cart>();
    
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var list = await _productService.GetProduct();
        ProductListView.ItemsSource = list;
        CartListView.ItemsSource = Carts.ToList();
        ProductListView.ItemsSource = list;
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

    private void AddToCart_Click(object sender, RoutedEventArgs e)
    {
        Product p = ProductListView.SelectedItem as Product;
        if (p != null)
        {
            Cart c = new Cart();
            c.Id = p.Id;
            c.Price = p.UnitPrice.Value;
            c.Quantity = 1;
            c.ProductName = p.Name;
            Carts.Add(c);
            CartListView.ItemsSource = Carts.ToList();
            decimal totalPrice = 0;
            foreach (var cart in Carts)
            {
                totalPrice += cart.Price;
            }
            lbTotalPrice.Content = totalPrice.ToString();
        }
    }

    private async void Payment_Click(object sender, RoutedEventArgs e)
    {
        List<Product> p = await _productService.GetProduct();
        _orderService.OrderPizza(_customer.Id, Carts);
        Carts.Clear();
        lbTotalPrice.Content = "";
        Window_Loaded(sender, e);
        UpdateLayout();
    }
    
    private void IntegerTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox != null)
        {
            string newText = textBox.Text + e.Text;
            int quantity;
            if (!int.TryParse(newText, out quantity))
            {
                e.Handled = true;
            }
        }
    }

    private async void IntegerTextBox_OnLostFocus(object sender, RoutedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string text = textBox.Text;
        int quantity = int.Parse(text);

        //So sanh
        Cart item = (Cart)CartListView.SelectedItem;
        if (item != null)
        {
            Product product = await _productService.GetByID(item.Id);
            if (quantity <= product.Quantity)
            {
                foreach (var c in Carts)
                {
                    if (c.Id == item.Id)
                    {
                        c.Quantity = quantity;
                        c.Price = item.Price * quantity;
                    }
                }
            }
            else
            {
                MessageBox.Show("Số lượng phải là một số nguyên và nhỏ hơn 100.");
            }
        }
        else
        {
            MessageBox.Show("Xin Hãy chọn vào sản phẩm rồi nhập số lượng");
        }

        CartListView.ItemsSource = Carts.ToList();
    }

    private void BtnBack_Click(object sender, RoutedEventArgs e)
    {
        CustomerWindow window = new CustomerWindow(_customer, _customerService , _productService , _orderService, _orderDetailService);
        window.Show();
        Close();
    }
}
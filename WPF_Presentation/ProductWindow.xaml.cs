using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using BussinessObject.IService;
using DataAccess.DataAccess;

namespace WPF_Presentation;

public partial class ProductWindow : Window
{
    private readonly ICustomerService _customerService;
    private readonly IOrderDetailService _orderDetailService;
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;

    public ProductWindow(ICustomerService customerService, IProductService productService, IOrderService orderService,
        IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
        _orderService = orderService;
        _productService = productService;
        _customerService = customerService;
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var list = await _productService.GetAll();
        ProductListView.ItemsSource = list;
        Alert.Content = "";
    }

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

    private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var helper = new WindowInteropHelper(this);
        SendMessage(helper.Handle, 161, 2, 0);
    }

    private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
    {
        MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void btnMaximize_Click(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Normal)
            WindowState = WindowState.Maximized;
        else WindowState = WindowState.Normal;
    }

    private void btnStatus_Click(object sender, RoutedEventArgs e)
    {
        var p = ProductListView.SelectedItem as Product;
        _productService.ChangeStatusProduct(p.Id);
        Window_Loaded(sender, e);
    }

    private async void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
        if (IsNumber(TxtQuantity.Text) == true || IsNumber(TxtPrice.Text) == true)
        {
            var product = new Product();
            product.Id = Guid.Parse(TxtId.Text);
            product.Name = TxtName.Text;
            product.Quantity = int.Parse(TxtQuantity.Text);
            product.Image = TxtImage.Text;
            product.UnitPrice = decimal.Parse(TxtPrice.Text);
            _productService.UpdateProduct(product);
            Window_Loaded(sender, e);
        }
        Alert.Content = "QUANTITY AND PRICE MUST BE NUMBER";
    }

    private Product getProduct()
    {
        if (IsNumber(TxtQuantity.Text) == false || IsNumber(TxtPrice.Text) == false)
        {
            Alert.Content = "QUANTITY AND PRICE MUST BE NUMBER";
            return null;
        }
        var product = new Product();
        product.Id = Guid.NewGuid();
        product.Name = TxtName.Text;
        product.Quantity = int.Parse(TxtQuantity.Text);
        product.Image = TxtImage.Text;
        product.UnitPrice = decimal.Parse(TxtPrice.Text);
        return product;
    }
    
    public bool IsNumber(string pText)
    {
        Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
        return regex.IsMatch(pText);
    }

    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        var check = "";
        if (check == "")
        {
            var p = getProduct();
            _productService.CreateProduct(p);
            Window_Loaded(sender, e);
        }
        else
        {
            Alert.Content = "CLEAR before ADD";
        }
    }

    private void btnClear_Click(object sender, RoutedEventArgs e)
    {
        TxtName.Text = string.Empty;
        TxtId.Text = string.Empty;
        TxtQuantity.Text = string.Empty;
        TxtPrice.Text = string.Empty;
        TxtImage.Text = string.Empty;
        Window_Loaded(sender, e);
    }

    private void BtnBack_Click(object sender, RoutedEventArgs e)
    {
        var window = new ManagermentWindow(_customerService, _productService, _orderService, _orderDetailService);
        window.Show();
        Close();
    }
}
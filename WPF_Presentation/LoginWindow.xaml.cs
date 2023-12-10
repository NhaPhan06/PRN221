using System.Windows;

namespace WPF_Presentation;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void BtnClose_OnClick(object sender, RoutedEventArgs e)
    {
        this. WindowState  = WindowState.Minimized;
    }
    
}
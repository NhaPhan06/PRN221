﻿using System.Windows;
using BussinessObject.IService;
using BussinessObject.IService.Service;
using DataAccess;
using DataAccess.IRepository;
using DataAccess.IRepository.IGeneric;
using DataAccess.IRepository.IUnitOfWork;
using DataAccess.IRepository.Repository;
using DataAccess.IRepository.Repository.Generic;
using DataAccess.IRepository.Repository.UnitOfWork;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WPF_Presentation;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider serviceProvider;

    public App()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        serviceProvider = serviceCollection.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection service)
    {
        service.AddDbContext<PizzaStoreContext>(options =>
            options.UseSqlServer(
                "server=DESKTOP-6NOOMUK\\SQLEXPRESS;database=PizzaStore;uid=sa;pwd=12345;TrustServerCertificate=True;MultipleActiveResultSets=true"));

//Add UNIT & GENERIC
        service.AddTransient(typeof(IGeneric<>), typeof(Generic<>));
        service.AddTransient<IUnitOfWork, UnitOfWork>();
//Add DI service
        service.AddTransient<ICustomerService, CustomerService>();
        service.AddTransient<IOrderService, OrderService>();
        service.AddTransient<IOrderDetailService, OrderDetailService>();
        service.AddTransient<IProductService, ProductService>();
        service.AddTransient<ICustomerRepo, CustomerRepo>();
        service.AddTransient<IOrderRepo, OrderRepo>();
        service.AddTransient<IOrderDetailRepo, OrderDetailRepo>();
        service.AddTransient<IProductRepo, ProductRepo>();
        service.AddSingleton<CustomerWindow>();
        service.AddSingleton<StorePizzaWindow>();
        service.AddSingleton<LoginWindow>();
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        var window = serviceProvider.GetService<LoginWindow>();
        window.Show();
    }
}
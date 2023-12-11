using BussinessObject.IService;
using BussinessObject.Service;
using DataAccess;
using DataAccess.DataAccess.Repository.Generic;
using DataAccess.DataAccess.Repository.UnitOfWork;
using DataAccess.IRepository;
using DataAccess.IRepository.IGeneric;
using DataAccess.IRepository.IUnitOfWork;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add DB
builder.Services.AddDbContext<PizzaStoreContext>(options => { options.UseSqlServer("server=DESKTOP-6NOOMUK\\SQLEXPRESS;database=PizzaStore;uid=sa;pwd=12345;TrustServerCertificate=True;MultipleActiveResultSets=true"); });


// Add services to the container.
builder.Services.AddRazorPages();

//Add UNIT & GENERIC
builder.Services.AddTransient(typeof(IGeneric<>), typeof(Generic<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

//Add DI service
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderDetailService, OrderDetailService>();
builder.Services.AddTransient<IProductService, ProductService>();


builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();
builder.Services.AddTransient<IOrderRepo, OrderRepo>();
builder.Services.AddTransient<IOrderDetailRepo, OrderDetailRepo>();
builder.Services.AddTransient<IProductRepo, ProductrRepo>();

builder.Services.AddSession();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();

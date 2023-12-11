using AutoMapper;
using BussinessObject.CartService;
using BussinessObject.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.IUnitOfWork;

namespace BussinessObject.Service;

public class OrderService : IOrderService
{
    private IUnitOfWork _unitOfWork;
    private IOrderDetailService _detailService;

    public OrderService(IUnitOfWork unitOfWork, IOrderDetailService detailService)
    {
        _unitOfWork = unitOfWork;
        _detailService = detailService;
    }
    public async Task<List<Order>> GetAllOrder()
    {
        return _unitOfWork.Order.GetAll().ToList();
    }

    public Task<List<Order>> GetOrderOfCustomer(Guid customerId)
    {
        return _unitOfWork.Order.GetAllOrderOfCustomer(customerId);
    }

    public async Task OrderPizza(Guid customer, List<Cart> carts)
    {
        List<Product> list = _unitOfWork.Product.GetAll().ToList();
        Order order = new Order();
        order.Id = Guid.NewGuid();
        order.OrderDate = DateTime.Now;
        order.CustomerId = customer;
        order.Status = "Prepare";
        _unitOfWork.Order.Add(order);

        foreach (var c in carts)
        {
            _detailService.CreateOrderDetail(order.Id, c.Id, c.Price, c.Quantity);
            list.Find(p => p.Id == c.Id).Quantity -= c.Quantity;
            _unitOfWork.Save();
        }
    }

    public async Task CancleOrder(Guid id)
    {
        _unitOfWork.Order.GetById(id).Status = "Cancel";
        _detailService.CancelOrderDetail(id);
        _unitOfWork.Save();
        
    }
}
using BussinessObject.CartService;
using DataAccess.DataAccess;
using DataAccess.IRepository.IUnitOfWork;

namespace BussinessObject.IService.Service;

public class OrderService : IOrderService
{
    private readonly IOrderDetailService _detailService;
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork, IOrderDetailService detailService)
    {
        _unitOfWork = unitOfWork;
        _detailService = detailService;
    }

    public async Task<List<Order>> GetAllOrder()
    {
        return await _unitOfWork.Order.GetAllOrderDesc();
    }

    public Task<List<Order>> GetOrderOfCustomer(Guid customerId)
    {
        return _unitOfWork.Order.GetAllOrderOfCustomer(customerId);
    }

    public async Task OrderPizza(Customer customer, List<Cart> carts)
    {
        decimal total = 0;
        var list = _unitOfWork.Product.GetAll().ToList();
        var order = new Order();
        order.Id = Guid.NewGuid();
        order.OrderDate = DateTime.Now;
        order.CustomerId = customer.Id;
        order.ShipAddress = customer.Address;
        order.Status = "Prepare";
        _unitOfWork.Order.Add(order);

        foreach (var c in carts)
        {
            _detailService.CreateOrderDetail(order.Id, c.Id, c.Price, c.Quantity);
            list.Find(p => p.Id == c.Id).Quantity -= c.Quantity;
            total += c.Price;
            _unitOfWork.Save();
        }

        order.Price = total;
        _unitOfWork.Order.Update(order);
        _unitOfWork.Save();
    }

    public async Task CancleOrder(Guid id)
    {
        _unitOfWork.Order.GetById(id).Status = "Cancel";
        _detailService.CancelOrderDetail(id);
        _unitOfWork.Save();
    }

    public async Task TransportProduct(Guid id)
    {
        _unitOfWork.Order.GetById(id).Status = "Transport";
        _unitOfWork.Save();
    }
}
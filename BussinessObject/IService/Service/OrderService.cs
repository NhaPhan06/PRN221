using AutoMapper;
using BussinessObject.CartService;
using BussinessObject.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.IUnitOfWork;

namespace BussinessObject.Service;

public class OrderService : IOrderService
{
    private IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<Order>> GetAllOrder()
    {
        return _unitOfWork.Order.GetAll().ToList();
    }

    public Task<List<Order>> GetOrderOfCustomer(Guid customerId)
    {
        return _unitOfWork.Order.GetAllOrderOfCustomer(customerId);
    }

    public Task OrderPizza()
    {
        throw new NotImplementedException();
    }
}
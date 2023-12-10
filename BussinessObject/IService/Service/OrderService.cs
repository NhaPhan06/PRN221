using AutoMapper;
using BussinessObject.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.IUnitOfWork;

namespace BussinessObject.Service;

public class OrderService : IOrderService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<Order>> GetAllOrder()
    {
        return _unitOfWork.Order.GetAll().ToList();
    }

    public Task<List<Order>> GetOrderOfCustomer(Guid customerId)
    {
        return _unitOfWork.Order.GetAllOrderOfCustomer(customerId);
    }
}
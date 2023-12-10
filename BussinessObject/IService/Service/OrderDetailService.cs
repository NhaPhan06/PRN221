using AutoMapper;
using BussinessObject.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.IUnitOfWork;

namespace BussinessObject.Service;

public class OrderDetailService : IOrderDetailService
{
    private IUnitOfWork _unitOfWork;

    public OrderDetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<OrderDetail> orderDetail(Guid id)
    {
        return _unitOfWork.OrderDetail.GetById(id);
    }

    public async Task<OrderDetail> CreateOrderDetail(Guid orderId ,Guid productId, decimal unitPrice, int quantity)
    {
        OrderDetail orderDetail = new OrderDetail();
        orderDetail.Id = Guid.NewGuid();
        orderDetail.OrderId = orderId;
        orderDetail.ProductId = productId;
        orderDetail.Quantity = quantity;
        orderDetail.UnitPrice = unitPrice;
        return orderDetail;
    }
}
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
        _unitOfWork.OrderDetail.Add(orderDetail);
        return orderDetail;
    }

    public async Task<List<OrderDetail>> GetDetailOfOrder(Guid id)
    {
        return _unitOfWork.OrderDetail.getOrderDetails(id);
    }

    public async Task CancelOrderDetail(Guid id)
    {
        var list = await GetDetailOfOrder(id);
        foreach (var o in list)
        {
            _unitOfWork.Product.GetById(o.ProductId).Quantity += o.Quantity;
            _unitOfWork.Save();
        }
    }
}
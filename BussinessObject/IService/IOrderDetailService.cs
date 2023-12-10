﻿using DataAccess.DataAccess;

namespace BussinessObject.IService;

public interface IOrderDetailService
{
    public Task<OrderDetail> orderDetail(Guid id);
    public Task<OrderDetail> CreateOrderDetail(Guid orderId, Guid productId, decimal unitPrice, int quantity);
}
﻿using DataAccess.DataAccess;
using DataAccess.IRepository.IGeneric;

namespace DataAccess.IRepository;

public interface IOrderDetailRepo : IGeneric<OrderDetail>
{
    List<OrderDetail> getOrderDetails(Guid id);
}
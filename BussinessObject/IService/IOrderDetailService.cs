using DataAccess.DataAccess;

namespace BussinessObject.IService;

public interface IOrderDetailService
{
    public Task<OrderDetail> orderDetail(Guid id);
}
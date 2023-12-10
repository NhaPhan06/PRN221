using AutoMapper;
using BussinessObject.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.IUnitOfWork;

namespace BussinessObject.Service;

public class OrderDetailService : IOrderDetailService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<OrderDetail> orderDetail(Guid id)
    {
        return _unitOfWork.OrderDetail.GetById(id);
    }
}
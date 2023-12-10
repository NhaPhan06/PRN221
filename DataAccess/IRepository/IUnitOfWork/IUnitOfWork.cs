namespace DataAccess.IRepository.IUnitOfWork;

public interface IUnitOfWork
{
    ICustomerRepo Customer { get; }
    IOrderDetailRepo OrderDetail { get; }
    IOrderRepo Order { get; }
    IProductRepo Product { get; }
    void Save();
}
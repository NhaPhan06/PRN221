namespace DataAccess.IRepository.IUnitOfWork;

public interface IUnitOfWork
{
    ICustomerRepo Customer { get; }
    ICategoryRepo Category { get; }
    IAccountRepo Account { get; }
    IOrderDetailRepo OrderDetail { get; }
    IOrderRepo Order { get; }
    IProductRepo Product { get; }
    ISupplierRepo Supplier { get; }
    void Save();
}
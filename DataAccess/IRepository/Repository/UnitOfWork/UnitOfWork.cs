using DataAccess.Repository;

namespace DataAccess.IRepository.Repository.UnitOfWork;

public class UnitOfWork : IUnitOfWork.IUnitOfWork
{
    public readonly PizzaStoreContext _context;

    public UnitOfWork(PizzaStoreContext context)
    {
        _context = context;
        Customer = new CustomerRepo(_context);
        OrderDetail = new OrderDetailRepo(_context);
        Order = new OrderRepo(_context);
        Product = new ProductRepo(_context);
    }

    public ICustomerRepo Customer { get; }
    public IOrderDetailRepo OrderDetail { get; }
    public IOrderRepo Order { get; }
    public IProductRepo Product { get; }

    public void Save()
    {
        _context.SaveChanges();
    }
}
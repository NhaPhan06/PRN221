using DataAccess.IRepository;
using DataAccess.IRepository.IUnitOfWork;
using DataAccess.Repository;

namespace DataAccess.DataAccess.Repository.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public readonly PizzaStoreContext _context;

    public UnitOfWork(PizzaStoreContext context)
    {
        // ReSharper disable once RedundantAssignment
        _context = context;
        Customer = new CustomerRepo(_context);
        OrderDetail = new OrderDetailRepo(_context);
        Order = new OrderRepo(_context);
        Product = new ProductrRepo(_context);
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
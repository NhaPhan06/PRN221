using DataAccess.DataAccess;
using DataAccess.IRepository.IGeneric;

namespace DataAccess.IRepository;

public interface IProductRepo : IGeneric<Product>
{
    Task<List<Product>> GetProductForMenu();
    Task<List<Product>> Search(String name);
}
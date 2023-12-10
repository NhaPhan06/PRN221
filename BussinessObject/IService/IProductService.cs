using DataAccess.DataAccess;

namespace BussinessObject.IService;

public interface IProductService
{
    Task<Product> GetByID(Guid id);
    Task<List<Product>> GetProduct();
    Task<List<Product>> Search(String name);
}
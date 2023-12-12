using DataAccess.DataAccess;

namespace BussinessObject.IService;

public interface IProductService
{
    Task<Product> GetByID(Guid id);
    Task<List<Product>> GetProduct();
    Task<List<Product>> Search(string name);
    Task<List<Product>> GetAll();
    Task CreateProduct(Product product);
    Task ChangeStatusProduct(Guid id);
    Task UpdateProduct(Product product);
}
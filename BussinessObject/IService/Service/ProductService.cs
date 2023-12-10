
using BussinessObject.IService;
using DataAccess.IRepository.IUnitOfWork;
using DataAccess.DataAccess;

namespace BussinessObject.Service;

public class ProductService :IProductService
{
    private IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> GetByID(Guid id)
    {
        return _unitOfWork.Product.GetById(id);
    }

    public async Task<List<Product>> GetProduct()
    {
        var listProduct = await _unitOfWork.Product.GetProductForMenu();
        return listProduct;
    }

    public async Task<List<Product>> Search(string name)
    {
        var listProduct = await _unitOfWork.Product.Search(name);
        return null;
    }
}
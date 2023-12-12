using DataAccess.DataAccess;
using DataAccess.IRepository.IUnitOfWork;

namespace BussinessObject.IService.Service;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

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

    public async Task<List<Product>> GetAll()
    {
        return _unitOfWork.Product.GetAll().ToList();
    }

    public async Task CreateProduct(Product product)
    {
        product.Status = "Stocking";
        _unitOfWork.Product.Add(product);
        _unitOfWork.Save();
    }

    public async Task ChangeStatusProduct(Guid id)
    {
        var p = _unitOfWork.Product.GetById(id);
        if (p.Status == "Stocking")
            p.Status = "OutOfStock";
        else
            p.Status = "Stocking";
        _unitOfWork.Save();
    }

    public async Task UpdateProduct(Product product)
    {
        var p = _unitOfWork.Product.GetById(product.Id);
        p.UnitPrice = product.UnitPrice;
        p.Quantity = product.Quantity;
        p.Name = product.Name;
        p.Image = product.Image;
        _unitOfWork.Product.Update(p);
        _unitOfWork.Save();
    }
}
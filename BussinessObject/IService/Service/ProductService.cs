using AutoMapper;
using BussinessObject.DTOS;
using BussinessObject.IService;
using DataAccess.IRepository.IUnitOfWork;
using BussinessObject.Mapper;

namespace BussinessObject.Service;

public class ProductService :IProductService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Menu>> GetMenu()
    {
        var listProduct = await _unitOfWork.Product.GetProductForMenu();
        List<Menu> menu = new List<Menu>();
        if (listProduct.Count > 0)
        {
            menu = _mapper.Map<List<Menu>>(listProduct);
        }
        return menu;
    }

    public async Task<List<Menu>> Search(string name)
    {
        var listProduct = await _unitOfWork.Product.Search(name);
        return _mapper.Map<List<Menu>>(listProduct);
    }
}
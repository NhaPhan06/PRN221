using BussinessObject.DTOS;

namespace BussinessObject.IService;

public interface IProductService
{
    Task<List<Menu>> GetMenu();
    Task<List<Menu>> Search(String name);
}
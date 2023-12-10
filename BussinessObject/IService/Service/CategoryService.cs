using AutoMapper;
using BussinessObject.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.IUnitOfWork;

namespace BussinessObject.Service;

public class CategoryService :ICategoryService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public void CreateCategory(string Name, string des)
    {
        Category category = new Category();
        category.Id = new Guid();
        category.Description = des;
        category.Name = Name;
        _unitOfWork.Category.Add(category);
        _unitOfWork.Save();
    }
}
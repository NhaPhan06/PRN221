using DataAccess.DataAccess;
using DataAccess.DataAccess.Repository.Generic;
using DataAccess.IRepository;

namespace DataAccess.Repository;

public class CategoryRepo :Generic<Category>, ICategoryRepo
{
    public CategoryRepo(PizzaStoreContext context) : base(context)
    {
    }
}
using DataAccess.DataAccess;
using DataAccess.DataAccess.Enum;
using DataAccess.DataAccess.Repository.Generic;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class ProductrRepo : Generic<Product>, IProductRepo
{
    public ProductrRepo(PizzaStoreContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetProductForMenu()
    {
        return await _context.Products.Where(p => p.Status.Equals(ProductStatus.Active.ToString())).ToListAsync();
    }

    public async Task<List<Product>> Search(string name)
    {
        return await _context.Products
            .Where(p => p.Status.Equals(ProductStatus.Active.ToString()) && p.Name.Contains(name)).ToListAsync();
    }
}
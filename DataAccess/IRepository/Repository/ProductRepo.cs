using DataAccess.DataAccess;
using DataAccess.IRepository.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.IRepository.Repository;

public class ProductRepo : Generic<Product>, IProductRepo
{
    public ProductRepo(PizzaStoreContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetProductForMenu()
    {
        return await _context.Products.Where(p => p.Status == "Stocking").ToListAsync();
    }

    public async Task<List<Product>> Search(string name)
    {
        return await _context.Products
            .Where(p => p.Status == "Active" && p.Name.Contains(name)).ToListAsync();
    }
}
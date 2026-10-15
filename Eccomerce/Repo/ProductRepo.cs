using Eccomerce.App_Context;
using Eccomerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eccomerce.Repo
{
    public class ProductRepo : GenarciRepo<Product>, IProductRepo
    {
        public ProductRepo(AppDbContext cotext) : base(cotext)
        {
        }
        public async Task<Product> filterProducts()
        {
            return await _context.Products.OrderByDescending(a => a.Price).Skip(1).Take(1).FirstOrDefaultAsync();
        }
        public async Task<Product> SearchByname(string Name)
        {
            return await _context.Products.FirstOrDefaultAsync(a => a.ProductName == Name);
        }


    }
}

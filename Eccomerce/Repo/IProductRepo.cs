using Eccomerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eccomerce.Repo
{
    public interface IProductRepo:IGenariceRepo<Product>
    {
        public Task<Product> filterProducts();
        public Task<Product> SearchByname(string Name);

    }
}

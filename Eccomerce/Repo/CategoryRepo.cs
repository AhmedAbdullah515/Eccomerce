using Eccomerce.App_Context;
using Eccomerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Eccomerce.Repo
{
    public class CategoryRepo : GenarciRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(AppDbContext cotext) : base(cotext)
        {
        }
        public async Task<List<Category>> Pagination(int pagenumber, int pagesize)
        {
            return await _context.Categories.OrderBy(a=>a.CategoryId).Skip((pagenumber-1)*pagesize).Take(pagesize).ToListAsync();
        }

    }
}

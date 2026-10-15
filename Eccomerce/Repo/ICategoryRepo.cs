using Eccomerce.Models;

namespace Eccomerce.Repo
{
    public interface ICategoryRepo:IGenariceRepo<Category>
    {
        public Task<List<Category>> Pagination(int pagenumber,int pagesize) ;
    }
}

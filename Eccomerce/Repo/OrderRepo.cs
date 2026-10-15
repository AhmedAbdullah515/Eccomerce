using Eccomerce.App_Context;
using Eccomerce.Models;

namespace Eccomerce.Repo
{
    public class OrderRepo : GenarciRepo<Order>, IOrder
    {
        public OrderRepo(AppDbContext cotext) : base(cotext)
        {
        }
    }
}

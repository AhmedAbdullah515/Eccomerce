using Eccomerce.Models;

namespace Eccomerce.Repo
{
    public interface IUnitWork
    {
        public IAuth Auth { get; }
        public IProductRepo ProductRepo { get; }
        public IOrder Order { get; }
        public ICategoryRepo CategoryRepo { get; }
        public IGenariceRepo<OrderItem> OrderItemRepo { get; }
        public IGenariceRepo<User> Userrepo { get; }
        public void Save();
    }
}

using Eccomerce.App_Context;
using Eccomerce.Models;

namespace Eccomerce.Repo
{
    public class UnitOfWorkRepo:IUnitWork
    {
        private readonly AppDbContext _context;

        public UnitOfWorkRepo(AppDbContext context, IAuth auth, IProductRepo productRepo, IOrder order,ICategoryRepo categoryRepo, IGenariceRepo<OrderItem> orderItemRepo, IGenariceRepo<User> userrepo)
        {
            _context = context;
            Auth = auth;
            ProductRepo = productRepo;
            Order = order;
            CategoryRepo = categoryRepo;
            OrderItemRepo = orderItemRepo;
            Userrepo = userrepo;
        }

        public IAuth Auth { get; }
        public IProductRepo ProductRepo { get; }
        public IOrder Order { get; }
        public ICategoryRepo CategoryRepo { get; }
        public IGenariceRepo<OrderItem> OrderItemRepo { get; }
        public IGenariceRepo<User> Userrepo { get; }
        public  void Save()
        {
            _context.SaveChanges();
        }
    }
}

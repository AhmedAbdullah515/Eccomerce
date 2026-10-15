using Eccomerce.Models;

namespace Eccomerce.Repo
{
    public interface IAuth
    {
        public Task<User>GetByEmail(string email);
        public Task Add(User user);
    }
}

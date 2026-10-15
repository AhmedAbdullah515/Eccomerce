using Eccomerce.App_Context;
using Eccomerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Eccomerce.Repo
{
    public class AuthRepo : IAuth
    {
        private readonly AppDbContext _context;
        public AuthRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}

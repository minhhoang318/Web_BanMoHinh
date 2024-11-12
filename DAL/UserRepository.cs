using DAL.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly BanMoHinh _context;

        public UserRepository(BanMoHinh context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}

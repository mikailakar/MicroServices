using Microsoft.EntityFrameworkCore;
using UserService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Interfaces;

namespace UserService.Implements
{
    public class UsersService : IUsersService
    {
        private readonly UserContext _context;
        public UsersService(UserContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
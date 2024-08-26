using UserService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserService.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
    }
}
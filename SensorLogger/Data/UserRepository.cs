using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SensorLogger.Models;

namespace SensorLogger.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly SensorLoggerContext _context;

        public UserRepository(SensorLoggerContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAndPasswordAsync(string username, string password)
        {
            List<User> users = await _context.Users.AsNoTracking().ToListAsync();
            User user = users.SingleOrDefault(u => u.Name == username && u.Password == password);
            return user;
        }

        public async Task<User> AddNewUserAsync(string username, string password)
        {
            List<User> users = await _context.Users.AsNoTracking().ToListAsync();
            User user = users.SingleOrDefault(u => u.Name == username && u.Password == password);
            return user;
        }
    }
}

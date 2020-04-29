using SensorLogger.Models;
using System.Threading.Tasks;

namespace SensorLogger.Data
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAndPasswordAsync(string username, string password);
        Task<User> AddNewUserAsync(string username, string password);
    }
}

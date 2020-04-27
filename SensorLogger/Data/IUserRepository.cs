using SensorLogger.Models;

namespace SensorLogger.Data
{
    public interface IUserRepository
    {
        User GetByUsernameAndPassword(string username, string password);
    }
}

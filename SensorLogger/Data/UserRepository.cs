using System.Collections.Generic;
using System.Linq;
using SensorLogger.Models;

namespace SensorLogger.Data
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Mads", Password = "i23", Role = "Admin" }
        };

        public User GetByUsernameAndPassword(string username, string password)
        {
            var user = users.SingleOrDefault(u => u.Name == username && u.Password == password);
            return user;
        }
    }
}

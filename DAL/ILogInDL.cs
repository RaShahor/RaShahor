using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface ILogInDL
    {
        Task<List<User>> GetAllUsers();
        Task<User> PostUser(string email, string pwd);
        Task<User> PostUser(User user);
        void PutUser(string email, User user);
    }
}
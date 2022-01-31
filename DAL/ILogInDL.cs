using Entities;
using System.Threading.Tasks;

namespace DAL
{
    public interface ILogInDL
    {
        Task<User> GetUser(string psw, string email);
        Task<User> PostUser(User user);
        void PutUser(string email, User user);
    }
}
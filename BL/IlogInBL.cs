using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IlogInBL
    {
        Task<List<User>> GetUser(string mail, string password);
    }
}
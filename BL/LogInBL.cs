using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
namespace BL
{
    public class LogInBL:IlogInBL
    {
        ILogInDL ILogIn;
        public LogInBL(ILogInDL iLogIn)
        {
            this.ILogIn = iLogIn;
        }
        public async Task<User> PostUser(string psw, string email)
        {
            return await ILogIn.PostUser(psw, email);
        }
        public async Task<User> PostUser(User user)
        {
            
            return await ILogIn.PostUser(user);
        }
        public async void PutUser(string email, User user)
        {
            user.Person.Mail = email;
            ILogIn.PutUser(email, user);
        }
    }
}

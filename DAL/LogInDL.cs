using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace DAL
{
    public class LogInDL : ILogInDL
    {
        SignContext myContext;

        ILogger logger;


        public LogInDL(SignContext myC)
        {
            myContext = myC;

            this.logger = logger;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await myContext.Users.ToListAsync();
        }
        public async Task<User> PostUser(string email, string pwd) 
        {
           //await
            return (User) myContext.Users.Where(x => x.Person.Mail == email && x.Person.Password == pwd);

        }

        public async Task<User> PostUser(User user)
        {
            myContext.Users.AddAsync(user);
            myContext.SaveChangesAsync();
            //await?
            return  user ;
        }

        public async Task<User> PutUser( string email,User user)
        {
            var userToUpdate=myContext.Users.FindAsync(user.Id);
            if (userToUpdate == null)
                return null;
            myContext.Entry(userToUpdate).CurrentValues.SetValues(user);
            await myContext.SaveChangesAsync();
            return user;

        }
        /*     //public User getUser(string login, string password)
        //{
        //    using (StreamReader reader = System.IO.File.OpenText("M:\\WebAPI")
        //    {
        //        string currentUser;
        //        while ((currentUser = reader.ReadLine()) != null)
        //        {

        //            User user = JsonContent.DeserializeObject<User>(currentUser);
        //            if (user.email == login && user.password == password)
        //                return user;
        //        }
        //    }
        //    return null;

        //}
        public async Task<User> GetUser(string psw, string email)
        {
            string path = @"M:\WebAPI\mainProject\Users.txt";
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string currentUser;
                while ((currentUser = await reader.ReadLineAsync()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUser);
                    if (user.email == email && user.password == psw)
                        return user;
                }
                return null;
            }
        }

        public async Task<User> PostUser(User user)
        {
            string path = @"M:\WebAPI\mainProject\Users.txt";
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            user.ID = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            await System.IO.File.AppendAllTextAsync(path, userJson + Environment.NewLine);
            return user;
        }

        public async void PutUser(string mail, User newuser)
        {
            User user = new User();
            string path = @"M:\web\firstweb1\Users.txt";
            string textToReplace = "";
            using (StreamReader reader = System.IO.File.OpenText(path))
            {

                string currentUser;
                while ((currentUser = await reader.ReadLineAsync()) != null)
                {

                    user = JsonSerializer.Deserialize<User>(currentUser);
                    if (user.email == mail)
                    {
                        textToReplace = currentUser;
                        break;
                    }

                }

            }

            if (textToReplace != string.Empty)
            {
                string text = await System.IO.File.ReadAllTextAsync(path);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(newuser));
                await System.IO.File.WriteAllTextAsync(path, text);

            }

        }
*/
    }
}

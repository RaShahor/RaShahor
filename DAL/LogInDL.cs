using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LogInDL : ILogInDL
    {
        public Task<User> GetUser(string psw, string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> PostUser(User user)
        {
            throw new NotImplementedException();
        }

        public void PutUser(string email, User user)
        {
            throw new NotImplementedException();
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

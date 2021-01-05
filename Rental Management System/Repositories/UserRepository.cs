using Rental_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rental_Management_System.Repositories
{
    public class UserRepository: Repository<User>
    {
        //Admin
        public User CheckLogin(String uname, String pass)
        {

            return this.GetAll().Where(x => x.UserName == uname && x.Password == pass).FirstOrDefault();
        }

        public IEnumerable<User> GetAllUsers()
        {

            return this.GetAll().Where(x => x.Type == 1).ToList();
        }

        public List<User> GetSearch(string find)
        {
            return this.GetAll().Where(x => x.Type == 1 && x.Name.Contains(find)).ToList();
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using WebApplication2.DAL;

namespace WebApplication2.Models
{
    public class UserBL
    {
        public List<User> GetUsers()
        {
            DB mDB = new DB();
            return mDB.userDB.ToList();
        }

        public void AddUser(User u)
        {
            DB mDB = new DB();
            mDB.userDB.Add(u);
            mDB.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication2.Models;
using WebApplication2.ViewModels.Authentication;

namespace WebApplication2.DAL
{
    public class DB :DbContext
    {
        public DB() : base("gr2")
        {

        }

        public DbSet<User> userDB { get; set; }

        public DbSet<LoginVM> adminsDB { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.ViewModels.User;


namespace WebApplication2.ViewModels.User
{
    public class EditVM : UserVM
    {
        public UserVM user { get; set; }
        public string username { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.ViewModels.User;
using System.ComponentModel.DataAnnotations;


namespace WebApplication2.ViewModels.User
{
    public class CreateVM : UserVM
    {
        
        public UserVM user { get; set; }
        public string username { get; set; }
    }
}
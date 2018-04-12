using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.User
{
    public class UserVM : WebApplication2.Models.User
    {
        public UserVM()
        {
            
        }

        public UserVM(WebApplication2.Models.User u)
        {
            userID = u.userID;
            firstName = u.firstName;
            lastName = u.lastName;
            age = u.age;
        }
        [Display(Name = "Nazwisko i imię")]
        public string name
        {
            get
            {
                return lastName + "" + firstName;
            }
        }
        public string colorAge
        {
            get
            {
                if (age < 18)
                {
                    return "yellow";
                }
                return "white";
            }
        }
    }
}
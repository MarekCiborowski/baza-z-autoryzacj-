using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Display(Name ="ID")]
        [Required(ErrorMessage = "ID wymagane")]
        public int userID { get; set; }
        [Display(Name ="Imię")]
        [Required(ErrorMessage = "Imię wymagane")]
        public string firstName { get; set; }
        [Display(Name ="Nazwisko")]
        [Required(ErrorMessage = "Nazwisko wymagane")]
        public string lastName { get; set; }
        [Display(Name ="Wiek")]
        [Range(1, 100, ErrorMessage = "Wiek musi być z zakresu 1-100")]
        [Required(ErrorMessage = "Wiek wymagany")]
        public int age { get; set; }
    }
}
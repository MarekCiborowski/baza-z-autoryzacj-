using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.ViewModels.Authentication
{
    [Table("AuthorizedUsers")]
    public class LoginVM
    {

        [Key]
        public int loginID { get; set; }
        [Display(Name = "Użytkownik")]
        [Required(ErrorMessage ="Wymagana nazwa użytkownika")]
        public string username { get; set; }
        [Required(ErrorMessage ="Wymagane hasło")]
        [Display(Name = "Hasło")]
        public string password { get; set; }
        public string hashPassword()
        {
            MD5 md5hash = MD5.Create();
            
            return GetMd5Hash(md5hash, password);
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
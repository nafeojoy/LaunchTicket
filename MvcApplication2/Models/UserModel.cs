using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Models
{
   
    public class UserModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The username is required")]
        [DisplayName("user_name")]
        public string user_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }

        //[RegularExpression("/^\\d{10}$/",ErrorMessage = "Invalid Email")]
        
        public string contact_no { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string gender { get; set; }
        public string occupation { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength=6,ErrorMessage="Range = 6-20 letters ")]
        [DisplayName("Password")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("password", ErrorMessage = "Password and confirm password must be the same.")]
        public string confirmpassword { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Invalid Email")]
        [DisplayName("email")]
        public string email { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "The username is empty")]
        [DisplayName("user_name")]
        public string user_name { get; set; }

        [Required(ErrorMessage = "The password is empty")]
        [DisplayName("password")]
        public string password { get; set; }
    }
}
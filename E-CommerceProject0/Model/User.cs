using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceProject0.Model
{
    public class UserLogin
    {
   
        public string Email { get; set; }

        public string Password { get; set; }

    }


    public class UserRegister
    {


        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime Birthdate { get; set; }

        //Date x = new Date();
    }


    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime birthdate { get; set; }

        public List<UserPaymentReport> UserPaymentReports { get; set; }
        public List<Order> Orders { get; set; }
        //public C_Payment Payment { get; set; }

        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public City? City { get; set; }
    }
}

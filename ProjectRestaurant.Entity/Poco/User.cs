using ProjectRestaurant.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.Poco
{
    public class User:AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public Roles Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
    }

    public enum Roles
    {
        [Display(Name = "Administrator")]
        Admin = 1,
        [Display(Name = "Regular User")]
        User = 2
    }
}

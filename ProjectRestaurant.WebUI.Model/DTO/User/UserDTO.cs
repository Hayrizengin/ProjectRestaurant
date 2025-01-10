using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.WebUI.Model.DTO.User
{
    public class UserDTO
    {
        //Update
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.Empty;

        //Request
        public string FirstName { get; set; } = "string";
        public string LastName { get; set; } = "string";
        public string FullName => $"{FirstName} {LastName}";
        public string PhoneNumber { get; set; } = "string";
        public Roles Role { get; set; }
        public string Email { get; set; } = "string";
        public string Password { get; set; } = "string";
        public string? ImageUrl { get; set; } = "string";

        //Response
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public enum Roles
    {
        [Display(Name = "Administrator")]
        Admin = 1,
        [Display(Name = "Regular User")]
        User = 2
    }
}

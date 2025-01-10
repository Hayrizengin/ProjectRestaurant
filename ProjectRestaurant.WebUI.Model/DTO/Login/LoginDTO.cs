using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.WebUI.Model.DTO.Login
{
    public class LoginDTO
    {
        //Request
        public string Email { get; set; } = "string";
        public string Password { get; set; } = "string";

        //Response
        public Guid Guid { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string PhoneNumber { get; set; }

        public string Token { get; set; }
    }
}

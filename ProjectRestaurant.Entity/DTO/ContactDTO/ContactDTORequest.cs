using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.DTO.ContactDTO
{
    public class ContactDTORequest
    {
        public string Address { get; set; } = "string";
        public string Phone { get; set; } = "string";
        public string Email { get; set; } = "string";
    }
}

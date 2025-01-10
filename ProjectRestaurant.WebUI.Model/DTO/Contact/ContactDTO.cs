using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.WebUI.Model.DTO.Contact
{
    public class ContactDTO
    {
        //Update
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.Empty;

        //Request
        public string Address { get; set; } = "string";
        public string Phone { get; set; } = "string";
        public string Email { get; set; } = "string";

        //Response
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

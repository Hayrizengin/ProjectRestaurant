using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.DTO.MessageDTO
{
    public class MessageDTORequest
    {
        public string Name { get; set; } = "string";
        public string Email { get; set; } = "string";
        public string Subject { get; set; } = "string";
        public string Content { get; set; } = "string";
        public bool IsActive { get; set; } = true;
    }
}

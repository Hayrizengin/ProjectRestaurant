using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.DTO.AboutDTO
{
    public class AboutDTORequest
    {
        public string Title { get; set; } = "string";
        public string Description { get; set; } = "string";
        public string? ImageUrl { get; set; } = "string";
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

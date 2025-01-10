using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.WebUI.Model.DTO.About
{
    public class AboutDTO
    {
        //Update
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.Empty;

        //Request
        public string Title { get; set; } = "string";
        public string Description { get; set; } = "string";
        public string ImageUrl { get; set; } = "string";

        //Response
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

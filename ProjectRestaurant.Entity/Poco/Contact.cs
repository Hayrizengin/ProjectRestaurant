using ProjectRestaurant.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.Poco
{
    public class Contact: AuditableEntity
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

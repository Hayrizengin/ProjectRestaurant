using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectRestaurant.DataAccess.Mapping.BaseMap;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.DataAccess.Mapping
{
    public class ContactMap: BaseMap<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.Property(q => q.Address).HasMaxLength(400).IsRequired();
            builder.Property(q => q.Phone).HasMaxLength(20).IsRequired();
            builder.Property(q => q.Email).HasMaxLength(80).IsRequired();
        }
    }
}

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
    public class MessageMap:BaseMap<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");
            builder.Property(q => q.Name).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Email).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Subject).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Content).HasMaxLength(500).IsRequired();
        }
    }
}

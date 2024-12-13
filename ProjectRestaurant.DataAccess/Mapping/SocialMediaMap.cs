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
    public class SocialMediaMap:BaseMap<SocialMedia>
    {
        public override void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMedias");
            builder.Property(q => q.Icon).HasMaxLength(200).IsRequired();
            builder.Property(q => q.Url).HasMaxLength(150).IsRequired();

        }
    }
}

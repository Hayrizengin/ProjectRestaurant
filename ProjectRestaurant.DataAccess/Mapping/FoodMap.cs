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
    public class FoodMap:BaseMap<Food>
    {
        public override void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.ToTable("Foods");
            builder.Property(q => q.Name).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Price).HasMaxLength(10).IsRequired();
            builder.Property(q => q.ImageUrl).HasMaxLength(200).IsRequired();
            builder.HasOne(q => q.FoodCategory).WithMany(q => q.Foods).HasForeignKey(q => q.FoodCategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

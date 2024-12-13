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
    public class FoodCategoryMap:BaseMap<FoodCategory>
    {
        public override void Configure(EntityTypeBuilder<FoodCategory> builder)
        {
            builder.ToTable("FoodCategories");
            builder.Property(q => q.Name).HasMaxLength(100).IsRequired();
        }
    }
}

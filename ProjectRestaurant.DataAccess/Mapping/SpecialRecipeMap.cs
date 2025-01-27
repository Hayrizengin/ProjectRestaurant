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
    public class SpecialRecipeMap:BaseMap<SpecialRecipe>
    {
        public override void Configure(EntityTypeBuilder<SpecialRecipe> builder)
        {
            builder.ToTable("SpecialRecipes");
            builder.Property(q => q.Title).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Description).HasMaxLength(800).IsRequired();

        }
    }
}

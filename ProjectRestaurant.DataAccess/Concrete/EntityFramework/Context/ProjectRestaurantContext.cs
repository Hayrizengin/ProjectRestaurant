using Microsoft.EntityFrameworkCore;
using ProjectRestaurant.DataAccess.Mapping;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.DataAccess.Concrete.EntityFramework.Context
{
    public class ProjectRestaurantContext : DbContext
    {
        public ProjectRestaurantContext()
        {

        }
        public ProjectRestaurantContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodCategory> FoodCategory { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<SpecialRecipe> SpecialRecipe { get; set; }
        public DbSet<About> About { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=AHLTEK-EMREKAYA;initial Catalog=RestaurantDb;integrated Security=true;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AboutMap());
            modelBuilder.ApplyConfiguration(new BannerMap());
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new FoodCategoryMap());
            modelBuilder.ApplyConfiguration(new FoodMap());
            modelBuilder.ApplyConfiguration(new MessageMap());
            modelBuilder.ApplyConfiguration(new SocialMediaMap());
            modelBuilder.ApplyConfiguration(new SpecialRecipeMap());


            base.OnModelCreating(modelBuilder);
        }

    }
}

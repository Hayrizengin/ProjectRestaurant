using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectRestaurant.DataAccess.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.DataAccess.Concrete.EntityFramework.Context;
using ProjectRestaurant.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.DataAccess.Concrete.EntityFramework.DataManagement
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ProjectRestaurantContext _restaurantContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EfUnitOfWork(ProjectRestaurantContext restaurantContext, IHttpContextAccessor httpContextAccessor)
        {
            _restaurantContext = restaurantContext;
            _httpContextAccessor = httpContextAccessor;
            AboutRepository = new EfAboutRepository(_restaurantContext);
            BannerRepository = new EfBannerRepository(_restaurantContext);
            ContactRepository = new EfContactRepository(_restaurantContext);
            FoodCategoryRepository = new EfFoodCategoryRepository(_restaurantContext);
            FoodRepository = new EfFoodRepository(_restaurantContext);
            MessageRepository = new EfMessageRepository(_restaurantContext);
            SocialMediaRepository = new EfSocialMediaRepository(_restaurantContext);
            SpecialRecipeRepository = new EfSpecialRecipeRepository(_restaurantContext);
            UserRepository = new EfUserRepository(_restaurantContext);
        }

        public IAboutRepository AboutRepository { get; }
        public IBannerRepository BannerRepository { get; }
        public IContactRepository ContactRepository { get; }
        public IFoodCategoryRepository FoodCategoryRepository { get; }
        public IFoodRepository FoodRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public ISocialMediaRepository SocialMediaRepository { get; }
        public ISpecialRecipeRepository SpecialRecipeRepository { get; }
        public IUserRepository UserRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            foreach (EntityEntry<AuditableEntity> item in _restaurantContext.ChangeTracker.Entries<AuditableEntity>())
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.AddedUser = 1;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.AddedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.UpdatedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                    if (item.Entity.IsActive == null)
                    {
                        item.Entity.IsActive = true;
                    }
                    item.Entity.IsDeleted = false;
                }
                else if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.UpdatedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }
            }
            return await _restaurantContext.SaveChangesAsync();
        }
    }
}

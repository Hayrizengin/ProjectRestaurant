using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.DataAccess.Abstract.DataManagement
{
    public interface IUnitOfWork
    {
        IAboutRepository AboutRepository { get; }
        IBannerRepository BannerRepository { get; }
        IContactRepository ContactRepository { get; }
        IFoodCategoryRepository FoodCategoryRepository { get; }
        IFoodRepository FoodRepository { get; }
        IMessageRepository MessageRepository { get; }
        ISocialMediaRepository SocialMediaRepository { get; }
        ISpecialRecipeRepository SpecialRecipeRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveChangeAsync();

    }
}

using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.DataAccess.Abstract
{
    public interface IUserRepository:IRepository<User>
    {
    }
}

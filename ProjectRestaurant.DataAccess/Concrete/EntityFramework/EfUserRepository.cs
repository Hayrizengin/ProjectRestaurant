using Microsoft.EntityFrameworkCore;
using ProjectRestaurant.DataAccess.Abstract;
using ProjectRestaurant.DataAccess.Concrete.EntityFramework.DataManagement;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.DataAccess.Concrete.EntityFramework
{
    public class EfUserRepository : EfRepository<User>, IUserRepository
    {
        private readonly DbContext _context;

        public EfUserRepository(DbContext context) : base(context)
        {

            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}

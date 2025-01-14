﻿using Microsoft.EntityFrameworkCore;
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
    public class EfFoodCategoryRepository : EfRepository<FoodCategory>, IFoodCategoryRepository
    {
        public EfFoodCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}

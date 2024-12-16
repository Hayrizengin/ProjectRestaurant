﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.DTO.FoodDTO
{
    public class FoodDTOResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string FoodCategoryName { get; set; }
        public int FoodCategoryId { get; set; }
    }
}
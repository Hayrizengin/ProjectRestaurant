﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.DTO.FoodCategoryDTO
{
    public class FoodCategoryDTOUpdateRequest
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
    }
}

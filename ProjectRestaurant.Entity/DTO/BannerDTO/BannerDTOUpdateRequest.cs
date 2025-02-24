﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.DTO.BannerDTO
{
    public class BannerDTOUpdateRequest
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}

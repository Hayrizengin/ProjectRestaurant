﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.DTO.SocialMediaDTO
{
    public class SocialMediaDTOUpdateRequest
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}

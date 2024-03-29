﻿using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Dtos.WorkLocationDto
{
    public class CreateWorkLocationDto
    {
        public string WorkLocationName { get; set; }
        public string WorkLocationCity { get; set; }

        public List<AppUser> AppUsers { get; set; }

    }
}

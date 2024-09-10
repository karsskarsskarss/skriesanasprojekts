﻿using mvcprojekts.Data.Enum;
using mvcprojekts.Models;

namespace mvcprojekts.ViewModels
{
    public class CreateRaceViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public RaceCategory RaceCategory { get; set; }
        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }

}


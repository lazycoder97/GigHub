﻿using GigHub.Controllers.Api;
using System;

namespace GigHub.Dtos
{
    public class GigDto
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }
        public UserDto Artist { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public GerneDto Gerne { get; set; }
    }
}
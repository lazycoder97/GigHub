using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [FutureTime]
        public string Time { get; set; }

        [Required]
        public byte Gerne { get; set; }

        public IEnumerable<Gerne> Gernes { get; set; }

        public DateTime GetDateTime() => DateTime.Parse(string.Format("{0} {1}", Date, Time));
    }
}
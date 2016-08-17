using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required, StringLength(255)]
        public string Venue { get; set; }

        public Gerne Gerne { get; set; }

        [Required]
        public byte GerneId { get; set; }
    }
}
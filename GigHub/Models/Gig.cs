using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required, StringLength(255)]
        public string Venue { get; set; }

        public Gerne Gerne { get; set; }

        [Required]
        public byte GerneId { get; set; }

        public List<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new List<Attendance>();
        }

        public void Cancel()
        {
            IsCanceled = true;
            
            var notification = new Notification(this, NotificationType.GigCanceled);
            
            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);
        }

        public void Modify(DateTime newDateTime, byte newGerneId, string newVenue)
        {
            var notification = new Notification(this, NotificationType.GigUpdated);
            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);

            DateTime = newDateTime;
            GerneId = newGerneId;
            Venue = newVenue;
        }
    }
}
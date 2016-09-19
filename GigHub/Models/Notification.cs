using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }

        protected Notification()
        {
        }

        public Notification(Gig gig, NotificationType type)
        {
            if (gig == null)
                throw new ArgumentNullException("gig");

            Gig = gig;
            Type = type;
            DateTime = DateTime.Now;

            switch (type)
            {
                case NotificationType.GigUpdated:
                    OriginalDateTime = gig.DateTime;
                    OriginalVenue = gig.Venue;
                    break;
                case NotificationType.GigCanceled:
                    break;
                case NotificationType.GigCreated:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
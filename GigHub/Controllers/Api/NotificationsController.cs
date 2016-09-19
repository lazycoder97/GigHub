using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext context;

        public NotificationsController()
        {
            context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = context.UserNotifications
                                       .Where(un => un.UserId == userId && un.IsRead == false)
                                       .Select(un => un.Notification)
                                       .Include(n => n.Gig.Artist)
                                       .ToList();

            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();

            return notifications.Select(Mapper.Map<NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var userNotifications = context.UserNotifications
                                           .Where(un => un.UserId == userId && !un.IsRead)
                                           .ToList();

            userNotifications.ForEach(un => un.Read());
            context.SaveChanges();

            return Ok();
        }
    }
}

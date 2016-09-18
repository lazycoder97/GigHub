using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    public class GigCancelController : ApiController
    {
        private ApplicationDbContext context;

        public GigCancelController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Cancel(GigCancelDto dto)
        {
            var userId = User.Identity.GetUserId();
            var gig = context.Gigs.Single(g => g.Id == dto.gigId && g.ArtistId == userId);

            if (gig.IsCanceled)
                return NotFound();

            gig.IsCanceled = true;
            context.SaveChanges();

            return Ok();
        }
    }
}

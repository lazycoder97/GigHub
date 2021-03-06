﻿using GigHub.Models;
using GigHub.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;

        public HomeController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index(string query = null)
        {
            var upcommingGigs = context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Gerne)
                .Where(g => g.DateTime > DateTime.Now && g.IsCanceled == false);

            if (!string.IsNullOrWhiteSpace(query))
            {
                upcommingGigs = upcommingGigs.Where(g => g.Artist.Name.Contains(query) ||
                                                         g.Gerne.Name.Contains(query) ||
                                                         g.Venue.Contains(query));
            }

            var viewModel = new GigViewModel
            {
                UpcommingGigs = upcommingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcomming Gigs",
                SearchTerm = query
            };

            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
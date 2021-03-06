using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.ViewModels
{
    public class GigViewModel
    {
        public IEnumerable<Gig> UpcommingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}
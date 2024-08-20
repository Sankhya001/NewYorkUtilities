using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewYorkUtilities.Models
{
    public class CollegesViewModel
    {
        public decimal Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SiteLink { get; set; }
        public string LogoName { get; set; }
        public string OtherInfo { get; set; }
    }

    public class CollegesListViewModel
    {
        public List<CollegesViewModel> CollegesList = new List<CollegesViewModel>();
    }
}
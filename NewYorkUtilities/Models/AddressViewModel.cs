using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NewYorkUtilities.Models
{
    public class AddressViewModel
    {
        public decimal Id { get; set; }  
        [Required]      
        public Nullable<int> Category { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string SiteLink { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public Nullable<decimal> Pincode { get; set; }
        public List<SelectListItem> listCategories { get; set; }
    }
    public class AddressListViewModel
    {
        public List<SelectListItem> listCategories { get; set; }
        public List<AddressViewModel> AddressList = new List<AddressViewModel>();
    }
}
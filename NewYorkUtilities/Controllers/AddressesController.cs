using NewYorkUtilities.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewYorkUtilities.Models;


namespace NewYorkUtilities.Controllers
{
    public class AddressesController : Controller
    {
        public UtilitiesDAL utilitiesDAL = new UtilitiesDAL(NewYorkUtilitiesEntities.GetInstance());
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Addresses(string SelectFilter)
        {
            try { 
            AddressListViewModel vm = new AddressListViewModel();

            var objCategories = utilitiesDAL.GetAllAddressCategories();
            List<SelectListItem> listDDL = (objCategories.Select(g => new SelectListItem()
            {
                Value = g.Id.ToString(),
                Text = g.Category.ToString(),
                Selected = g.Id.ToString() == SelectFilter ? true : false
            })).ToList();

            listDDL.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "-Select Item-",
                Selected = SelectFilter == null ? true : false
            });

            vm.listCategories = listDDL;
            vm.AddressList = new List<AddressViewModel>();
            if(SelectFilter != null)
            {
                var addresses = utilitiesDAL.GetAddressesByCategory(Convert.ToInt32(SelectFilter));
                List<AddressViewModel> objAddressList = new List<AddressViewModel>();
                foreach (var address in addresses)
                {
                    AddressViewModel obj = new AddressViewModel
                    {
                        Id = address.Id,
                        Category = address.Category,
                        Name = address.Name,
                        Description = address.Description,
                        SiteLink = address.SiteLink,
                        Phone = address.Phone,
                        Email = address.Email,
                        Street1 = address.Street1,
                        Street2 = address.Street2,
                        City = address.City,
                        Pincode = address.Pincode
                    };

                    objAddressList.Add(obj);
                }
                vm.AddressList = objAddressList;
            }

            return View(vm);
            }
            catch (Exception ex)
            {
                //Log Error stacktrace and message
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult AddAddress()
        {
            try
            {
                AddressViewModel vm = new AddressViewModel();
                var objCategories = utilitiesDAL.GetAllAddressCategories();
                List<SelectListItem> listDDL = (objCategories.Select(g => new SelectListItem()
                {
                    Value = g.Id.ToString(),
                    Text = g.Category.ToString()
                })).ToList();

                listDDL.Insert(0, new SelectListItem()
                {
                    Value = "0",
                    Text = "-Select Item-",
                    Selected = true
                });

                vm.listCategories = listDDL;
                return View(vm);
            }
            catch (Exception ex)
            {
                //Log Error stacktrace and message
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public ActionResult AddAddress(AddressViewModel model)
        {
            try { 
            if(!ModelState.IsValid)
            {
                var objCategories = utilitiesDAL.GetAllAddressCategories();
                List<SelectListItem> listDDL = (objCategories.Select(g => new SelectListItem()
                {
                    Value = g.Id.ToString(),
                    Text = g.Category.ToString()
                })).ToList();

                listDDL.Insert(0, new SelectListItem()
                {
                    Value = "0",
                    Text = "-Select Item-",
                    Selected = true
                });

                model.listCategories = listDDL;

                return View(model);
            }

            tblAddress address = new tblAddress
            {
                Category = model.Category,
                Name = model.Name,
                SiteLink = model.SiteLink,
                Phone = model.Phone,
                Email = model.Email,
                Street1 = model.Street1,
                Street2 = model.Street2,
                City = model.City,
                Pincode = model.Pincode
            };

            var result = utilitiesDAL.AddAddress(address);

            if(result == "Success")
            {
                return RedirectToAction("Addresses", new { SelectFilter = Convert.ToString(model.Category) });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            }
            catch (Exception ex)
            {
                //Log Error stacktrace and message
                return RedirectToAction("Error", "Home");
            }
        }

    }
}
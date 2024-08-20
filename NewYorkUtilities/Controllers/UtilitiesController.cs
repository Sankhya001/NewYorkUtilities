using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using NewYorkUtilities.DataAccess;
using NewYorkUtilities.Models;

namespace NewYorkUtilities.Controllers
{
    public class UtilitiesController : Controller
    {

        public UtilitiesDAL utilitiesDAL = new UtilitiesDAL(NewYorkUtilitiesEntities.GetInstance());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            try
            {
                var path = Server.MapPath("\\Content\\Images\\Gallery");
                var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

                List<string> imageFiles = new List<string>();
                foreach (string filename in files)
                {
                    imageFiles.Add(Path.GetFileName(filename));
                }

                return View(imageFiles);
            }
            catch (Exception ex)
            {
                //Log Error stacktrace and message
                return RedirectToAction("Error", "Home");
            }
        }


        public ActionResult EngineeringColleges()
        {
            try
            {
                CollegesListViewModel vm = new CollegesListViewModel();

                var colleges = utilitiesDAL.GetAllEngineeringColleges();

                List<CollegesViewModel> objCollegesList = new List<CollegesViewModel>();
                foreach (var college in colleges)
                {
                    CollegesViewModel obj = new CollegesViewModel
                    {
                        Id = college.Id,
                        Type = college.Type,
                        Name = college.Name,
                        Description = college.Description,
                        SiteLink = college.SiteLink,
                        LogoName = college.LogoName,
                        OtherInfo = college.OtherInfo
                    };

                    objCollegesList.Add(obj);
                }

                ViewBag.Title = "Engineering Colleges";

                vm.CollegesList = objCollegesList;
                return View(vm);
            }
            catch (Exception ex)
            {
                //Log Error stacktrace and message
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult MedicalColleges()
        {
            try
            {
                CollegesListViewModel vm = new CollegesListViewModel();

                var colleges = utilitiesDAL.GetAllMedicalColleges();

                List<CollegesViewModel> objCollegesList = new List<CollegesViewModel>();
                foreach (var college in colleges)
                {
                    CollegesViewModel obj = new CollegesViewModel
                    {
                        Id = college.Id,
                        Type = college.Type,
                        Name = college.Name,
                        Description = college.Description,
                        SiteLink = college.SiteLink,
                        LogoName = college.LogoName,
                        OtherInfo = college.OtherInfo
                    };

                    objCollegesList.Add(obj);
                }

                ViewBag.Title = "Medical Colleges";

                vm.CollegesList = objCollegesList;
                return View("EngineeringColleges", vm);
            }
            catch (Exception ex)
            {
                //Log Error stacktrace and message
                return RedirectToAction("Error", "Home");
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseProject.Models;
using Repositories;
using DataAccess;
using CourseProject.Helpers;

namespace CourseProject.Controllers
{
    public class CityController : Controller
    {
        public ActionResult Edit()
        {
            CityRepository repo = new CityRepository();

            CityViewModel model = new CityViewModel(repo.GetAll());
            return View(model);
        }

        [HttpGet]
        public ActionResult EditCity(int id = 0)
        {
            if (!LoginUserSession.Current.IsAdministrator)
            {
                return RedirectToAction("Edit");
            }

            CityRepository repo = new CityRepository();

            CityViewModel city = new CityViewModel();

            City cityDb = repo.GetByID(id);

            if (cityDb != null)
            {
                city = new CityViewModel(cityDb);
            }

            return View(city);

        }

        [HttpPost]
        public ActionResult EditCity(CityViewModel model)
        {

            CityRepository repo = new CityRepository();
            City city = repo.GetByID(model.ID);
            if (city == null) city = new City();
            city.Name = model.Name;
            repo.Save(city);
            return RedirectToAction("Edit");

        }

        public ActionResult Delete(int id = 0)
        {

            if (!LoginUserSession.Current.IsAdministrator)
            {
                return Edit();
            }

            CityRepository repo = new CityRepository();

            if (repo.GetByID(id) != null)
            {
                City city = repo.GetByID(id);

                repo.DeleteByID(city.ID);

                TempData["Message"] = "Successfully deleted city!";
            }
            else
            {
                TempData["ErrorMessage"] = "No such city!";
            }
            return RedirectToAction("Edit");
        }


    }
}
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
    public class StoreController : Controller
    {
        public ActionResult Edit()
        {
            StoreRepository repo = new StoreRepository();

            StoreViewModel model = new StoreViewModel(repo.GetAll());
            return View(model);
        }

        [HttpGet]
        public ActionResult EditStore(int id = 0)
        {
            if (!LoginUserSession.Current.IsAdministrator)
            {
                return RedirectToAction("Edit");
            }

            CityRepository cityRepo = new CityRepository();

            List<City> cities = cityRepo.GetAll();

            ViewBag.Cities = new SelectList(cities, "ID", "Name");

            StoreRepository repo = new StoreRepository();

            StoreViewModel store = new StoreViewModel();

            Store storeDb = repo.GetByID(id);

            if (storeDb != null)
            {
                store = new StoreViewModel(storeDb);
            }

            return View(store);

        }

        [HttpPost]
        public ActionResult EditStore(StoreViewModel model)
        {

            StoreRepository repo = new StoreRepository();
            Store store = repo.GetByID(model.ID);
            if (store == null) store = new Store();
            store.Name = model.Name;
            store.City = model.CityID;
            store.Desciption = model.Description;
            repo.Save(store);
            return RedirectToAction("Edit");

        }

        public ActionResult Delete(int id = 0)
        {

            if (!LoginUserSession.Current.IsAdministrator)
            {
                return Edit();
            }

            StoreRepository repo = new StoreRepository();

            if (repo.GetByID(id) != null)
            {
                Store store = repo.GetByID(id);

                repo.DeleteByID(store.ID);

                TempData["Message"] = "Successfully deleted store!";
            }
            else
            {
                TempData["ErrorMessage"] = "No such store!";
            }
            return RedirectToAction("Edit");
        }


    }
}
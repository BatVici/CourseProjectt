﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;
using DataAccess;
using CourseProject.Helpers;
using CourseProject.Models;

namespace CourseProject.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (LoginUserSession.Current.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            LoginViewModel login = new LoginViewModel();
            return View(login);
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult LoginPost(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                UserRepository userRepository = new UserRepository();
                User dbUser = userRepository.GetUserByNameAndPassword(viewModel.UserName, viewModel.Password);

                bool isUserExists = dbUser != null;
                if (isUserExists)
                {
                    LoginUserSession.Current.SetCurrentUser(dbUser.ID, dbUser.Username, dbUser.Username == "admin");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username and/or password");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            if (LoginUserSession.Current.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            LoginViewModel login = new LoginViewModel();
            return View(login);
        }
        [HttpPost]
        public ActionResult Register(LoginViewModel login)
        {
            UserRepository repository = new UserRepository();
            if (repository.GetUserByName(login.UserName) == null)
            {
                User user = new User();
                user.Username = login.UserName;
                repository.RegisterUser(user, login.Password);
                LoginUserSession.Current.SetCurrentUser(user.ID, user.Username, user.Username == "admin");
                return RedirectToAction("Index", "Home");
            }
            return Register();
        }
        public ActionResult Logout()
        {
            LoginUserSession.Current.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
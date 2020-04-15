using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummitAfrica.Data;
using SummitAfrica.Models;
using SummitAfrica.Services;

namespace SummitAfrica.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly UserServices _UserServices;
        public UserController(ApplicationDbContext Context)
        {
            _Context = Context;
            _UserServices = new UserServices(Context);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserMainForm()
        {
            UserContactDetails model = new UserContactDetails();
            List<UserDataTable> UserList = new List<UserDataTable>();
            model.UserDataTableList = _UserServices.GetUserinfo(0);
            return View(model);
        }
        public IActionResult UserContact(Userxml UserDataxml)
        {
            _UserServices.UpdateUserDetails(UserDataxml);
            UserContactDetails model = new UserContactDetails();
            model.UserDataTableList = _UserServices.GetUserinfo(0);
            return PartialView("UserList", model);
        }
        public IActionResult Edit(int SN)
        {
            UserContactDetails model = new UserContactDetails();
            model.UserDataTableList = _UserServices.GetUserinfo(SN);
            Userxml Userxml = new Userxml();
            foreach(var item in model.UserDataTableList)
            {
                Userxml.SNo = item.SNo;
                Userxml.FirstName = item.FirstName;
                Userxml.LastName = item.LastName;
                Userxml.PhoneNumber = item.PhoneNumber;
                Userxml.Email = item.Email;
            }
            model.UserDataxml = Userxml;
            return PartialView("UserContact", model);
        }

        public IActionResult Delete(int SNo)
        {
            _UserServices.DeleteUserInfo(SNo);
            UserContactDetails model = new UserContactDetails();
            model.UserDataTableList = _UserServices.GetUserinfo(0);
            return PartialView("UserList", model);

        }
    }
}
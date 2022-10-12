using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace RegisterForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Login()
        {
            return View();
        }

         
        [HttpPost]
        public ActionResult Login(tbl_userdetails login)
        {
            RegistartionEntities db = new RegistartionEntities();

            var user = db.tbl_userdetails.Where(x => x.User_Name == login.User_Name && x.Password == login.Password).FirstOrDefault();

            if (user != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }


        [HttpGet]
        public ActionResult Registartion()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Registartion(tbl_userdetails tbl_Userdetails)
        {
            RegistartionEntities db = new RegistartionEntities();

            db.tbl_userdetails.Add(tbl_Userdetails);
            db.SaveChanges();
            return View(tbl_Userdetails);
        }
    }
}
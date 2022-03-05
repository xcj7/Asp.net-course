using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace shopbd.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.msg = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbluser usr)
        {
            myshopdbEntities obj = new myshopdbEntities();

            var a = obj.tblusers.Where(l => l.uname.Equals(usr.uname) && l.upass.Equals(usr.upass)).ToList();
            
            if(a.Count > 0)
            {
                Session["uname"] = usr.uname.ToString();
                return RedirectToAction("Dashbord");
             

            }
            else
            {
                ViewBag.msg = "Invalid Username or Password !";

            }
            
            return View();
        }


        public ActionResult Dashbord()
        {
            if (Session["uname"]==null)
            {
                ViewBag.msg = "Login Frist...!";
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
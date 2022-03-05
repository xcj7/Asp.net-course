using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopbd;
using shopbd.Models;

namespace shopbd.Controllers
{
    public class HomeController : Controller
    {
        myshopdbEntities db = new myshopdbEntities();
        // GET: Home
        public ActionResult Index()
        {
          
            var p = db.tblproes.ToList();
            ViewBag.p =p;
            var imgs = db.tblimages.ToList();
            ViewBag.imgs = imgs;
            return View();
        }


        public ActionResult cat (int id)
        {
            var p= db.tblproes.Where(l=>l.cid==id).ToList();
            ViewBag.p = p;
            var imgs = db.tblimages.ToList();
            ViewBag.imgs = imgs;
            return View();

        }

        public ActionResult pro(int id )
        {
            var p = db.tblproes.Where(l => l.pid == id).ToList();
            ViewBag.p = p;
            var imgs = db.tblimages.Where(l=>l.pid==id).ToList();
            ViewBag.imgs = imgs;
            return View();
        }

        public ActionResult About()

        {
            return View();
        }         
       
        public ActionResult cart()
        {
            ViewBag.c = ok.c;
            return View();
        }
        [HttpPost]
        public ActionResult cart(string pid, string pqty)
        {
            int id = int.Parse(pid);
            var item = db.tblproes.ToList();

            foreach (var p in ok.c)
            {
                if (p.iid == id)
                {
                    p.iqty += int.Parse(pqty);
                    ViewBag.c = ok.c;
                    ViewBag.item = item;
                    return View();

                }

            }
            cartitem i = new cartitem()
            {
                iid = id,
                iqty = int.Parse(pqty)

            };

            ok.c.Add(i);
            ViewBag.c = ok.c;
            ViewBag.item = item;

            return View();

        }

        [HttpPost]
        public ActionResult checkout(string total)
        {
            ViewBag.t = total;
            return View();
        }
       [HttpPost]
        public ActionResult doneorder(tblorder tb,string total)
        {
            /*
            tblorder obj = new tblorder();
            obj.odate = DateTime.Now.ToString();
            obj.oamount = int.Parse(total);
            obj.ostatus = 0;
            obj.opname = tb.opname;
            obj.opaddress = tb.opaddress;
            obj.opsaddress = tb.opsaddress;
            obj.opphone = tb.opphone;
            db.tblorders.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
            */

            tblorder obj = new tblorder();
            obj.odate = DateTime.Now.ToString();
            obj.oamount = int.Parse(total);
            obj.ostatus = 0;
            obj.opname = tb.opname;
            obj.opaddress = tb.opaddress;
            obj.opsaddress = tb.opsaddress;
            obj.opphone = tb.opphone;
            db.tblorders.Add(obj);
            db.SaveChanges();



           

            // max order id for order details
            int moid = db.tblorders.Select(a => a.oid).DefaultIfEmpty(0).Max();

            var pro = from prod in ok.c
                      join od in db.tblproes
                      on prod.iid equals od.pid
                      select new { PID=od.pid, PPRICE=od.pprice, PQTY= prod.iqty };


            tblorderdetail orderdetails = new tblorderdetail();

            foreach (var iteam in pro)
            {
                orderdetails.oid = moid;
                orderdetails.pid = iteam.PID;
                orderdetails.pprice = iteam.PPRICE;
                orderdetails.pqty = iteam.PQTY;
                orderdetails.pamount = iteam.PQTY * iteam.PPRICE;
                db.tblorderdetails.Add(orderdetails);
                db.SaveChanges();
            }

           
            return RedirectToAction("Index");
        }
    }
}
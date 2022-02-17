using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newsbangla.Models;
using newsbangla.Models.Database;
using System.Data.Entity;

namespace newsbangla.Controllers
{
    public class newsbanglaController : Controller
    {
        // GET: newsbangla
        public ActionResult Index()
        {
            List<news> Newslist = new List<news>();
            // List<studentEntities> studentlist = new List<studentEntities>();
            using (newsinfo NewsInfoEntitie = new newsinfo())
            {

                Newslist = NewsInfoEntitie.news.ToList<news>();
            }
            return View(Newslist);
        }


        // GET: News/Details/5
        public ActionResult Details(int Id)
        {
            news NewsModel = new news();
            using (newsinfo NewsInfoEntitie = new newsinfo())
            {
                NewsModel = NewsInfoEntitie.news.Where(x => x.Id == Id).FirstOrDefault();
            }
            return View(NewsModel);
        }



        // GET: News/Edit/5
        public ActionResult search(string catagory)
        {
            news NewsModel = new news();
            using (newsinfo NewsInfoEntitie = new newsinfo())
            {
                //NewsInfoEntitie.Database.
                 NewsModel = NewsInfoEntitie.news.Where(x => x.Category == catagory).FirstOrDefault();




               // var documents = GetMarketingDocumentsMock();
               /*
               
               documents.ForEach((document) =>
                {
                    indexRepository.IndexData<MarketingDocument>(document, "marketing");
                });


                */




            }
            return View(NewsModel);
        }


        /*
        // POST: News/Edit/5
        [HttpPost]
        public ActionResult search(news NewsModel)
        {
            using (newsinfo NewsInfoEntitie = new newsinfo())
            {
                NewsInfoEntitie.Entry(NewsModel).State = System.Data.EntityState.Modified;
                NewsInfoEntitie.SaveChanges();

            }
            return RedirectToAction("Index");
        }


        */



        // GET: News/Create
        public ActionResult Create()
        {
            return View(new news());
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create(news NewsModel)
        {
            using (newsinfo NewsInfoEntitie = new newsinfo())
            {
                NewsInfoEntitie.news.Add(NewsModel);
                NewsInfoEntitie.SaveChanges();
              

            }
            return RedirectToAction("Index");
        }

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            news NewsModel = new news();
            using (newsinfo NewsInfoEntitie = new newsinfo())
            {
                NewsModel = NewsInfoEntitie.news.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(NewsModel);
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult Edit(news NewsModel)
        {
            using (newsinfo NewsInfoEntitie = new newsinfo())
            {
                NewsInfoEntitie.Entry(NewsModel).State = System.Data.EntityState.Modified;
                NewsInfoEntitie.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            news NewsModel = new news();
            using (newsinfo NewsInfoEntitie = new newsinfo())
            {
                NewsModel = NewsInfoEntitie.news.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(NewsModel);
        }

        // POST: News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            using (newsinfo studentEntitie = new newsinfo())
            {
                news NewsModel = studentEntitie.news.Where(x => x.Id == id).FirstOrDefault();
                studentEntitie.news.Remove(NewsModel);
                studentEntitie.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

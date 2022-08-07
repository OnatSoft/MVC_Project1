using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StartProject.Models;

namespace MVC_StartProject.Controllers
{
    public class KategoriController : Controller
    {
        KitaplikDBwebEntities kitaplikDB = new KitaplikDBwebEntities();
        public ActionResult Index()
        {
            var kategoriList = kitaplikDB.KategoriTbl.ToList();
            return View(kategoriList);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(KategoriTbl s)
        {
            kitaplikDB.KategoriTbl.Add(s);
            kitaplikDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var categori = kitaplikDB.KategoriTbl.Find(id);
            kitaplikDB.KategoriTbl.Remove(categori);
            kitaplikDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var categoryGetir = kitaplikDB.KategoriTbl.Find(id);
            return View("KategoriGetir", categoryGetir);
        }

        public ActionResult KategoriGuncelle(KategoriTbl u)
        {
            var categoryUpdate = kitaplikDB.KategoriTbl.Find(u.ID);
            categoryUpdate.KategoriAd = u.KategoriAd;
            kitaplikDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
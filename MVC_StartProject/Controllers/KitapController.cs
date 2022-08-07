using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StartProject.Models;

namespace MVC_StartProject.Controllers
{
    public class KitapController : Controller
    {
        KitaplikDBwebEntities db = new KitaplikDBwebEntities();
        public ActionResult Index()
        {
            var kitaplar = db.KitapTbl.ToList();
            return View(kitaplar);
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(KitapTbl t)
        {
            db.KitapTbl.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.KitapTbl.Find(id);
            db.KitapTbl.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var kitap = db.KitapTbl.Find(id);
            return View("KitapGetir", kitap);
        }

        public ActionResult KitapGuncelle(KitapTbl kitapTbl)
        {
            var ktp = db.KitapTbl.Find(kitapTbl.KitapID);
            ktp.Adi = kitapTbl.Adi;
            ktp.Sayfano = kitapTbl.Sayfano;
            ktp.Yazar = kitapTbl.Yazar;
            ktp.Kategori = kitapTbl.Kategori;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
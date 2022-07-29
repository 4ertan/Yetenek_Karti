using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Skill_CodeFirstEntity.Models.Siniflar;
namespace Skill_CodeFirstEntity.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        CONTEXT c = new CONTEXT();
        public ActionResult Index()
        {
           
            var dgr = c.YETENEKLERS.ToList();
            return View(dgr);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(YETENEKLER y)
        {
            try
            {
                c.YETENEKLERS.Add(y);
                c.SaveChanges();
                return View();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public ActionResult Sil(int id)
        {
           var dgr= c.YETENEKLERS.Find(id);
            c.YETENEKLERS.Remove(dgr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Güncelle(int id)
        {
            var dgr = c.YETENEKLERS.Find(id);
            return View("Güncelle", dgr);
            
        }
        [HttpPost]
        public ActionResult Güncelle(YETENEKLER y)
        {
           
                var dgr = c.YETENEKLERS.Find(y.ID);
                dgr.ACIKLAMA = y.ACIKLAMA;
                dgr.DEGER = y.DEGER;
                c.SaveChanges();
            
           
            
            return RedirectToAction("Index");
        }
    }
}
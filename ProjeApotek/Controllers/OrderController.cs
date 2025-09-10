using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjeApotek.Models;
using System.Runtime.Intrinsics.Arm;

namespace ProjeApotek.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            using (MedicinContext db = new MedicinContext())
            {
                List<Medicin> medicinLista = db.Mediciner.ToList();
                return View(medicinLista);
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Medicin nyMedicin)
        {
            using (MedicinContext db = new MedicinContext())
            {
                db.Mediciner.Add(nyMedicin);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            using (MedicinContext db = new MedicinContext())
            {
                Medicin medicin = db.Mediciner.Find(id);
                return View(medicin);
            }

        }
       

        public IActionResult Edit(int id)
        {
            using (MedicinContext db = new MedicinContext())
            {
                Medicin medicin = db.Mediciner.Find(id);
                return View(medicin);
            }
        }
        [HttpPost]
        public IActionResult Edit(Medicin medicin)
        {
            using (MedicinContext db = new MedicinContext())
            {
                db.Update(medicin); 
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            using (MedicinContext db = new MedicinContext())
            {
                Medicin medicin = db.Mediciner.Find(id);
                return View(medicin);
            }
        }
        [HttpPost]
        public IActionResult Delete(Medicin medicin)
        {
            using (MedicinContext db = new MedicinContext())
            {
                db.Mediciner.Remove(medicin);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

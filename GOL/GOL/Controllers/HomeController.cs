using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GOL.Controllers
{
    public class HomeController : Controller
    {
        private GOLDbContext dbContext;
        public HomeController(GOLDbContext gol)
        {
            dbContext = gol;
        }

        public IActionResult Index()
        {
            return View(dbContext.Airplane);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Airplane airplane)
        {
            if (ModelState.IsValid)
            {
                dbContext.Airplane.Add(airplane);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Update(Guid id)
        {
            return View(dbContext.Airplane.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Airplane airplane)
        {
            dbContext.Airplane.Update(airplane);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var airplane = dbContext.Airplane.Where(a => a.Id == id).FirstOrDefault();
            dbContext.Airplane.Remove(airplane);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FinalProjectMovies.Models;

namespace FinalProjectMovies.Controllers
{
    public class CinemaLocationsController : Controller
    {
        private ApplicationDbContext _context;

        public CinemaLocationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CinemaLocations
        public IActionResult Index()
        {
            return View(_context.CinemaLocation.ToList());
        }

        // GET: CinemaLocations/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CinemaLocation cinemaLocation = _context.CinemaLocation.Single(m => m.ID == id);
            if (cinemaLocation == null)
            {
                return HttpNotFound();
            }

            return View(cinemaLocation);
        }

        // GET: CinemaLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CinemaLocations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CinemaLocation cinemaLocation)
        {
            if (ModelState.IsValid)
            {
                _context.CinemaLocation.Add(cinemaLocation);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cinemaLocation);
        }

        // GET: CinemaLocations/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CinemaLocation cinemaLocation = _context.CinemaLocation.Single(m => m.ID == id);
            if (cinemaLocation == null)
            {
                return HttpNotFound();
            }
            return View(cinemaLocation);
        }

        // POST: CinemaLocations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CinemaLocation cinemaLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cinemaLocation);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cinemaLocation);
        }

        // GET: CinemaLocations/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CinemaLocation cinemaLocation = _context.CinemaLocation.Single(m => m.ID == id);
            if (cinemaLocation == null)
            {
                return HttpNotFound();
            }

            return View(cinemaLocation);
        }

        // POST: CinemaLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CinemaLocation cinemaLocation = _context.CinemaLocation.Single(m => m.ID == id);
            _context.CinemaLocation.Remove(cinemaLocation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

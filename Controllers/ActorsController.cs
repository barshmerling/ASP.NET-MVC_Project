using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FinalProjectMovies.Models;

namespace FinalProjectMovies.Controllers
{
    public class ActorsController : Controller
    {
        private ApplicationDbContext _context;

        public ActorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Actors
        public IActionResult Index()
        {
            return View(_context.Actors.ToList());
        }

        // GET: Actors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Actor actor = _context.Actors.Single(m => m.ID == id);
            if (actor == null)
            {
                return HttpNotFound();
            }

            return View(actor);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Actors.Add(actor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: Actors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Actor actor = _context.Actors.Single(m => m.ID == id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(actor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Actor actor = _context.Actors.Single(m => m.ID == id);
            if (actor == null)
            {
                return HttpNotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Actor actor = _context.Actors.Single(m => m.ID == id);
            _context.Actors.Remove(actor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

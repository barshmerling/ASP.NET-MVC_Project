using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FinalProjectMovies.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectMovies.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public IQueryable<Movie> NULL { get; private set; }

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Movies.ToList());
        }


        //Search
        [HttpPost]
        public IActionResult Index1(string genre, int year, int rating)
        {

            var movies = from l in _context.Movies
                        where l.GenreOfMovie.Equals(genre) && l.ReleaseYearOfMovie==year && l.RatingOfMovie >= rating
                        select l;


            if (movies == NULL)
            {
                return View(_context.Movies.ToList());
            }

            else
            {
                return View("Index", movies.ToList());
            }
        }


        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie Movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(Movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Movie);
        }

        // GET: Movie/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movies.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Actors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie Movie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Movie);
        }


        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movies.Single(m => m.ID == id);
            if (movie == null){
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movies.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Movie movie = _context.Movies.Single(m => m.ID == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

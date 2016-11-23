using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FinalProjectMovies.Models;
using System.Net;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectMovies.Controllers
{
    public class ManageReviewsController : Controller
    {
        private ApplicationDbContext _context;
        public ManageReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<object> a = new List<object>();
            a.Add(_context.Reviews.ToList());
            a.Add(_context.Movies.ToList());
            a.Add(_context.Actors.ToList());
            a.Add(_context.CinemaLocation.ToList());
            return View(a);
        }



        //Blog/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Review Review = _context.Reviews.Single(m => m.ID == id);
            if (Review == null)
            {
                return HttpNotFound();
            }

            return View(Review);
        }



        public IActionResult Create()
        {
            return View();
        }


        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Review Review)
        {
            if (ModelState.IsValid)
            {
                //Add Current date
                DateTime now = DateTime.Now;
                Review.ReviewDate = now;
                _context.Reviews.Add(Review);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Review);
        }


        // GET: Blog/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Review Review = _context.Reviews.Single(m => m.ID == id);
            if (Review == null)
            {
                return HttpNotFound();
            }
            return View(Review);
        }

        // POST: Actors/Edit/5
        //ADDED Bind
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Review Review)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Review);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Review);
        }

        // GET: Blog/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Review Review = _context.Reviews.Single(m => m.ID == id);
            if (Review == null)
            {
                return HttpNotFound();
            }

            return View(Review);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Review Review = _context.Reviews.Single(m => m.ID == id);
            _context.Reviews.Remove(Review);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




        // GET: Review/ManageComments/5
        //[ActionName("Delete")]
        public IActionResult ManageComments(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            var comments = _context.Comments.Where(m => m.ReviewID == id).ToList();
            if (comments == null)
            {
                return HttpNotFound();
            }


            return View(comments);
        }


        // GET: Review/Delete/5
        [ActionName("DeleteComment")]
        public IActionResult DeleteComment(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Comment comment = _context.Comments.Single(m => m.ID == id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCommentConfirmed(int id)
        {
            Comment comment = _context.Comments.Single(m => m.ID == id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FinalProjectMovies.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectMovies.Controllers
{
    public class ReviewController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReviewController
        public IActionResult Index()
        {
            List<object> a = new List<object>();
            a.Add(_context.Reviews.ToList());
            a.Add(_context.Comments.ToList());
            return View(a);
        }

        //Search #1
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            // LINQ
            var reviews = from r in _context.Reviews
                        select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                //Where with contains
                reviews = reviews.Where(s => s.ReviewTitle.Contains(searchString));
            }
            List<object> list = new List<object>();
            list.Add(await reviews.ToListAsync());
            list.Add(_context.Comments.ToList());
            return View(list);
        }


        // POST: Review/CreateComment
        [HttpPost]
        public IActionResult CreateComment(string name, string title, string comment, int ReviewId)
        {
            Comment a = new Comment();
            a.CommentWriter = name;
            a.CommentTitle = title;
            a.CommentContent = comment;
            a.ReviewID = ReviewId;
            _context.Comments.Add(a);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

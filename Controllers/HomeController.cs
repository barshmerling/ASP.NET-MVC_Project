﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FinalProjectMovies.Models;

namespace FinalProjectMovies.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            //ViewData["Message"] = "Your contact page.";

            return View(_context.CinemaLocation.ToList());
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult ShowMovies()
        {
            return View();
        }


        public IActionResult Top5()
        {
            return View();
        }
    }


}

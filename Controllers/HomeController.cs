﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotDefterim.Data;
using NotDefterim.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NotDefterim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            // giriş yapmış kullanıcı yok ise
            if (!User.Identity.IsAuthenticated)
                return View("IndexAnonymous");

            // giriş yapmış kullanıcının id'si
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View(_db.Notes.Where(n => n.AuthorId == userId).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

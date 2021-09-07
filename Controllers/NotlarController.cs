using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotDefterim.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NotDefterim.Controllers
{
    [Authorize]
    public class NotlarController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NotlarController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(Note note)
        {
            if (ModelState.IsValid)
            {
                note.AuthorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _db.Notes.Add(note);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }

    internal class authorizeAttribute : Attribute
    {
    }
}

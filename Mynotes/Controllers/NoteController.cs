// NoteController.cs
using Microsoft.AspNetCore.Mvc;
using Mynotes.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Mynotes.ViewModels;
using Mynotes.Models;
using System.Linq;

namespace Mynotes.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public NoteController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /Note
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var notes = _context.Notes.Where(n => n.UserId == userId).ToList();
            return View(notes);
        }

        // GET: /Note/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new NoteViewModel());
        }

        // POST: /Note/Create
        [HttpPost]
        public IActionResult Create(NoteViewModel model)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if (ModelState.IsValid)
            {
                var note = new Note()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Color = model.Color,
                    UserId = userId
                };
                _context.Notes.Add(note);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /Note/Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var note = _context.Notes.FirstOrDefault(n => n.Id == id && n.UserId == userId);

            if (note != null)
            {
                var model = new NoteViewModel()
                {
                    Id = note.Id,
                    Title = note.Title,
                    Description = note.Description,
                    CreatedDate = note.CreatedDate,
                    Color = note.Color,
                    UserId = userId
                };

                return View(model);
            }
            else
            {
                return Content("You are not authorized or note not found");
            }
        }

        [HttpPost]
        public IActionResult Edit(NoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                var note = _context.Notes.FirstOrDefault(n => n.Id == model.Id && n.UserId == userId);

                if (note != null)
                {
                    note.Title = model.Title;
                    note.Description = model.Description;
                    note.Color = model.Color;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Content("You are not authorized or note not found");
                }
            }
            return View(model);
        }

        // GET: /Note/Delete
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return Content("Note Id is null");
            }

            var userId = _userManager.GetUserId(HttpContext.User);
            var note = _context.Notes.FirstOrDefault(n => n.Id == id && n.UserId == userId);

            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return Content("You are not authorized or note not found");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Mynotes.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity; 
using Mynotes.ViewModels;
using Mynotes.Models;

namespace Mynotes.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public NoteController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
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
            var currentUser = _userManager.GetUserAsync(User).Result;
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
    var note = _context.Notes.FirstOrDefault(n => n.Id == id);

    if (note != null && note.UserId == userId)
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
        return Content("You are not authorized");
    }
}

            
            
           
        }

    }


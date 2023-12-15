using Microsoft.AspNetCore.Mvc;
using Mynotes.Data;
namespace Mynotes.Controllers
{
    [Authorize]
    public class NoteController : Controllers
    {
       private readonly ApplicationDbContext _context;
        public NoteController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new NoteViewModel());
        }
    }
}
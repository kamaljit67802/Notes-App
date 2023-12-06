using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

namespace Mynotes.Controllers.API
{
    [Route("api/notes")]
    [ApiController]
    public class NoteApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NoteApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/notes
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetNotes()
        {
            return _context.Notes.ToList();
        }

        // GET: api/notes/1
        [HttpGet("{id}")]
        public ActionResult<Note> GetNoteById(int id)
        {
            var note = _context.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // POST: api/notes
        [HttpPost]
        public IActionResult PostNote([FromBody] Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetNoteById), new { id = note.NoteId }, note);
        }

        // PUT: api/notes/1
        [HttpPut("{id}")]
        public IActionResult PutNote(int id, [FromBody] Note note)
        {
            if (id != note.NoteId)
            {
                return BadRequest();
            }

            _context.Entry(note).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/notes/1
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var note = _context.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

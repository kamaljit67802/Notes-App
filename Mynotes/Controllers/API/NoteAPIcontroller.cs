// Controllers/Api/NoteApiController.cs
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

[Route("api/[controller]")]
[ApiController]
public class NoteApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public NoteApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/noteapi
    [HttpGet]
    public ActionResult<IEnumerable<Note>> GetNotes()
    {
        return _context.Notes.ToList();
    }

    // GET: api/noteapi/1
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

    // POST: api/noteapi
    [HttpPost]
    public IActionResult PostNote([FromBody] Note note)
    {
        _context.Notes.Add(note);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetNoteById), new { id = note.NoteId }, note);
    }

    // PUT: api/noteapi/1
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

    // DELETE: api/noteapi/1
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

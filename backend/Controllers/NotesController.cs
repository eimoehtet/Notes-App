using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
using NotesAPI.Repositories;

namespace NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesRepository _noteRepository;

        public NotesController(NotesRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

      
        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            var noteId = await _noteRepository.CreateNote(note);
            return CreatedAtAction(nameof(GetById), new { id = noteId }, note);
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _noteRepository.GetAllNotes();
            return Ok(notes);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _noteRepository.GetNoteById(id);
            if (note == null) return NotFound();
            return Ok(note);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Note note)
        {
            if (id != note.Id) return BadRequest("ID mismatch");

            var updated = await _noteRepository.UpdateNote(note);
            if (!updated) return NotFound();
            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _noteRepository.DeleteNote(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

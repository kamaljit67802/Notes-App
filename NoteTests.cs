using Xunit;
using Mynotes.Models;

namespace Mynotes.Tests
{
    public class NoteTests
    {
        [Fact]
        public void CanChangeNoteTitle()
        {
            // set title
            var note = new Note { Title = "Test" };

            // test title
            note.Title = "New Title";

            // Assert
            Assert.Equal("New Title", note.Title);
        }
    }
}

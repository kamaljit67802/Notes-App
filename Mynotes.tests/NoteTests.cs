

using Mynotes.Models;
using System;
using Xunit;

public class NoteTests
{
    [Fact]
    public void CanChangeTitle()
    {
        
        var note = new Note { Title = "Test Title" };

        
        note.Title = "New Title";

        
        Assert.Equal("New Title", note.Title);
    }

    [Fact]
    public void CanChangeDescription()
    {
        
        var note = new Note { Description = "Test Description" };

        
        note.Description = "New Description";

        
        Assert.Equal("New Description", note.Description);
    }
    
    [Fact]
    public void CanChangeColor()
    {
        
        var note = new Note { Color = "Test Color" };

        
        note.Color = "New Color";

        
        Assert.Equal("New Color", note.Color);
    }

    [Fact]
    public void CanChangeCreatedDate()
    {
        
        var note = new Note { CreatedDate = DateTime.Now };

        
        var newDate = DateTime.Now.AddDays(1);
        note.CreatedDate = newDate;

        
        Assert.Equal(newDate, note.CreatedDate);
    }
}

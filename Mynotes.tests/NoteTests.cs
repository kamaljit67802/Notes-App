// Mynotes.Tests.NoteTests.cs

using Mynotes.Models;
using System;
using Xunit;

public class NoteTests
{
    [Fact]
    public void CanChangeTitle()
    {
        // Arrange
        var note = new Note { Title = "Test Title" };

        // Act
        note.Title = "New Title";

        // Assert
        Assert.Equal("New Title", note.Title);
    }

    [Fact]
    public void CanChangeDescription()
    {
        // Arrange
        var note = new Note { Description = "Test Description" };

        // Act
        note.Description = "New Description";

        // Assert
        Assert.Equal("New Description", note.Description);
    }
    
    [Fact]
    public void CanChangeColor()
    {
        // Arrange
        var note = new Note { Color = "Test Color" };

        // Act
        note.Color = "New Color";

        // Assert
        Assert.Equal("New Color", note.Color);
    }

    [Fact]
    public void CanChangeCreatedDate()
    {
        // Arrange
        var note = new Note { CreatedDate = DateTime.Now };

        // Act
        var newDate = DateTime.Now.AddDays(1);
        note.CreatedDate = newDate;

        // Assert
        Assert.Equal(newDate, note.CreatedDate);
    }
}

// Tests/CategoryTests.cs
using Xunit;
using NotesApp.Models;

public class CategoryTests
{
    [Fact]
    public void CanCreateCategory()
    {
        var category = new Category
        {
            CategoryName = "Test Category"
        };  

        Assert.Equal("Test Category", category.CategoryName);
    }
}

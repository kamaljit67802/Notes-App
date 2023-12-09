// Mynotes.Tests.CategoryTests.cs

using Mynotes.Models;
using Xunit;

public class CategoryTests
{
    [Fact]
    public void CanChangeCategoryName()
    {
        
        var category = new Category { Name = "Test Category" };

        
        category.Name = "New Category";

        
        Assert.Equal("New Category", category.Name);
    }
}

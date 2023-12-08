// Mynotes.Tests.CategoryTests.cs

using Mynotes.Models;
using Xunit;

public class CategoryTests
{
    [Fact]
    public void CanChangeCategoryName()
    {
        // Arrange
        var category = new Category { Name = "Test Category" };

        // Act
        category.Name = "New Category";

        // Assert
        Assert.Equal("New Category", category.Name);
    }
}

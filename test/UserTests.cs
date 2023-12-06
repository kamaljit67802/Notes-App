using Xunit;
using Mynotes.Models;

namespace Mynotes.Tests
{
    public class UserTests
    {
        [Fact]
        public void CanChangeFirstName()
        {
            // set user to test
            var user = new User { FirstName = "Test" };

            // Act
            user.FirstName = "John Doe";

            // Assert
            Assert.Equal("John Doe", user.FirstName);
        }

        [Fact]
        public void CanChangeLastName()
        {
            // set
            var user = new User { LastName = "Test" };

            // fire
            user.LastName = "New Name";

            // check
            Assert.Equal("New Name", user.LastName);
        }
    }
}
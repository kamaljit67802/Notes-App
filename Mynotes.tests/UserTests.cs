using Xunit;
using Mynotes.Models;

namespace Mynotes.Tests
{
    public class UserTests
    {
        [Fact]
        public void CanChangeFirstName()
        {
            
            var user = new User { FirstName = "Test" };

            
            user.FirstName = "John Doe";

            
            Assert.Equal("John Doe", user.FirstName);
        }

        [Fact]
        public void CanChangeLastName()
        {
            
            var user = new User { LastName = "Test" };


            user.LastName = "New Name";

    
            Assert.Equal("New Name", user.LastName);
        }
    }
}
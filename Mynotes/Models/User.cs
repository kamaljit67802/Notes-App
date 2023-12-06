// Purpose: Model for the User table in the database.
// since identityUser already includes properties for Id, PasswordHash, and Email. No need to add it separately.
using Microsoft.AspNetCore.Identity;

namespace Mynotes.Models
{
public class User: IdentityUser
{
    public string? FirstName { get; set;}
    public string? LastName { get; set;}

}

}



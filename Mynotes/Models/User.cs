using Microsoft.AspNetCore.Identity;

namespace Mynotes.Models
{
public class User: IdentityUser
{
    public string? FirstName { get; set;}
    public string? LastName { get; set;}

}

}



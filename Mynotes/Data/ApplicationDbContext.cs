using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mynotes.Models;
using Microsoft.AspNetCore.Identity;


namespace Mynotes.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Note>? Notes { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}

using Microsoft.EntityFrameworkCore;
using CSE325_Group_Project.Models;

namespace CSE325_Group_Project.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<User> Users => Set<User>();
    public DbSet<BorrowedBook> BorrowedBooks => Set<BorrowedBook>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed a default admin user so you can log in right away
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "System Admin",
            Email = "admin@library.com",
            PasswordHash = "admin123",
            Role = "Admin"
        });
    }
}
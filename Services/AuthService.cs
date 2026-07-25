using Microsoft.EntityFrameworkCore;
using CSE325_Group_Project.Data;
using CSE325_Group_Project.Models;

namespace CSE325_Group_Project.Services;

public class AuthService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public AuthService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public bool IsLoggedIn { get; private set; }
    public User? CurrentUser { get; private set; }

    public async Task<bool> LoginAsync(string email, string password)
    {
        using var context = await _factory.CreateDbContextAsync();
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);

        if (user != null)
        {
            IsLoggedIn = true;
            CurrentUser = user;
            return true;
        }

        return false;
    }

    public void Logout()
    {
        IsLoggedIn = false;
        CurrentUser = null;
    }

    public async Task<bool> CreateAdminAsync(string name, string email, string password)
    {
        using var context = await _factory.CreateDbContextAsync();
        if (await context.Users.AnyAsync(u => u.Email == email))
            return false;

        context.Users.Add(new User 
        { 
            Name = name, 
            Email = email, 
            PasswordHash = password, 
            Role = "Admin" 
        });

        await context.SaveChangesAsync();
        return true;
    }

    // Overload for CreateAdmin.razor (takes email and password, extracts name from email)
    public async Task<bool> RegisterAdminAsync(string email, string password)
    {
        var name = email.Contains("@") ? email.Split('@')[0] : email;
        return await CreateAdminAsync(name, email, password);
    }
}
using Microsoft.EntityFrameworkCore;
using RegistrationForm.Models;

namespace RegistrationForm.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        DbSet<User> Users { get; set; } 
    }
}

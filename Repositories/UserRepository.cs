using Microsoft.EntityFrameworkCore;
using RegistrationForm.Data;
using RegistrationForm.Models;
using System.Buffers;
using System.Collections;

namespace RegistrationForm.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbContext _ctx;
        public UserRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<User>> GetAsync()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            _ctx.Add<User>(user);
            await _ctx.SaveChangesAsync();
        }
    }
}

using RegistrationForm.Data;
using RegistrationForm.Models;

namespace RegistrationForm.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbContext _ctx;
        public UserRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddAsync(User user)
        {
            _ctx.Add<User>(user);
            await _ctx.SaveChangesAsync();
        }
    }
}

using RegistrationForm.Models;

namespace RegistrationForm.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAsync();
        Task AddAsync(User user);
    }
}

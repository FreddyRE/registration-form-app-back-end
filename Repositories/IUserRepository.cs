using RegistrationForm.Models;

namespace RegistrationForm.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
    }
}

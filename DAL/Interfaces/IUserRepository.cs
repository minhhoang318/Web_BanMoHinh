using DAL.Models;
namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}

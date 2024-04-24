using MudBlazorWebApp5.Models;

namespace MudBlazorWebApp5.Account
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(Object id);
        Task<User> GetUserNamePassword(string username, string password);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(Object id);
    }
}

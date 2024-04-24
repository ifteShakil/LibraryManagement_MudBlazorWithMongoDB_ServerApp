using MudBlazorWebApp5.Models;

namespace MudBlazorWebApp5.IService
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> GetAuthorById(string id);
        Task CreateAuthor(Author author);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(string id);
    }
}

using MudBlazorWebApp5.Models;

namespace MudBlazorWebApp5.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(string Id);
        Task CreateCategory (Category category);
        Task UpdateCategory (Category category);
        Task DeleteCategory (string id);

    }
}

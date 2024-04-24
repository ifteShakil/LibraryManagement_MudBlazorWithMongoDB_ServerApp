using MudBlazorWebApp5.Models;

namespace MudBlazorWebApp5.IService
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategory>> GetSubCategories();
        Task<SubCategory> GetSubCategoryById(string Id);
        Task CreateSubCategory(SubCategory subCategory);
        Task UpdateSubCategory(SubCategory subCategory);
        Task DeleteSubCategory(string id);
    }
}

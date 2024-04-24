using MudBlazorWebApp5.Models;

namespace MudBlazorWebApp5.IService
{
    public interface IBookFloorService
    {
        Task<IEnumerable<BookFloor>> GetBookFloors();
        Task<BookFloor> GetBookFloorById(string id);
        Task CreateBookFloor(BookFloor bookFloor);
        Task UpdateBookFloor(BookFloor bookFloor);
        Task DeleteBookFloor(string id);
    }
}

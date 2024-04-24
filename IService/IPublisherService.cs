using MudBlazorWebApp5.Models;

namespace MudBlazorWebApp5.IService
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetPublishers();
        Task<Publisher> GetPublisherById(string id);
        Task CreatePublisher(Publisher publisher);
        Task UpdatePublisher(Publisher publisher);
        Task DeletePublisher(string id);
    }
}

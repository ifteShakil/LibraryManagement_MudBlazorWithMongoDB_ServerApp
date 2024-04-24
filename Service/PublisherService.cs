using MongoDB.Bson;
using MongoDB.Driver;
using MudBlazorWebApp5.IService;
using MudBlazorWebApp5.Models;

namespace MudBlazorWebApp5.Service
{
    public class PublisherService : IPublisherService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<Publisher> _publisherTable = null;

        public PublisherService()
        {
            _mongoClient = new MongoClient("mongodb+srv://iftekhar_shakil:iftekhar_shakil@cluster001.w8lyriq.mongodb.net/?retryWrites=true&w=majority&appName=Cluster001");
            _mongoDatabase = _mongoClient.GetDatabase("LibraryDB");
            _publisherTable = _mongoDatabase.GetCollection<Publisher>("Publishers");
        }

        public async Task CreatePublisher(Publisher publisher)
        {
            await _publisherTable.InsertOneAsync(publisher);
        }

        public async Task DeletePublisher(string id)
        {
            var filter = Builders<Publisher>.Filter.Eq(p => p.PublisherId, id);
            await _publisherTable.DeleteOneAsync(filter);
        }

        public async Task<Publisher> GetPublisherById(string id)
        {
            var filter = Builders<Publisher>.Filter.Eq(p => p.PublisherId, id);
            var cursor = await _publisherTable.FindAsync(filter);
            var publishers = await cursor.FirstOrDefaultAsync();
            return publishers;
        }

        public async Task<IEnumerable<Publisher>> GetPublishers()
        {
            var filter = Builders<Publisher>.Filter.Empty;
            var coursor = await _publisherTable.FindAsync(filter);
            var publishers = await coursor.ToListAsync();
            return publishers;
        }

        public async Task UpdatePublisher(Publisher publisher)
        {
            var filter = Builders<Publisher>.Filter.Eq(p => p.PublisherId, publisher.PublisherId);
            var d = await _publisherTable.Find(filter).FirstOrDefaultAsync();
            var res = await _publisherTable.ReplaceOneAsync(filter, publisher);
                     
        }

        
    }
}

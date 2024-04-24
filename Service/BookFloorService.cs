using MongoDB.Driver;
using MudBlazorWebApp5.IService;
using MudBlazorWebApp5.Models;

namespace MudBlazorWebApp5.Service
{
    public class BookFloorService : IBookFloorService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<BookFloor> _bookTable = null;


        public BookFloorService()
        {
            _mongoClient = new MongoClient("mongodb+srv://iftekhar_shakil:iftekhar_shakil@cluster001.w8lyriq.mongodb.net/?retryWrites=true&w=majority&appName=Cluster001");
            _mongoDatabase = _mongoClient.GetDatabase("LibraryDB");
            _bookTable = _mongoDatabase.GetCollection<BookFloor>("BookFloors");
        }

        public async Task CreateBookFloor(BookFloor bookFloor)
        {
            await _bookTable.InsertOneAsync(bookFloor);
        }

        public async Task DeleteBookFloor(string id)
        {
            var filter = Builders<BookFloor>.Filter.Eq(s => s.BookFloorId, id);
            await _bookTable.DeleteOneAsync(filter);
        }

        public async Task<BookFloor> GetBookFloorById(string id)
        {
            var filter = Builders<BookFloor>.Filter.Eq(s => s.BookFloorId, id);
            var cursor = await _bookTable.FindAsync(filter);
            var bookFloor = await cursor.FirstOrDefaultAsync(); // Use FirstOrDefaultAsync() from LINQ extensions
            return bookFloor;
        }

        public async Task<IEnumerable<BookFloor>> GetBookFloors()
        {
            var filter = Builders<BookFloor>.Filter.Empty; // Empty filter to get all shelves
            var cursor = await _bookTable.FindAsync(filter);
            var bookFloors = await cursor.ToListAsync(); // Use ToListAsync() from LINQ extensions
            return bookFloors;
        }

        public async Task UpdateBookFloor(BookFloor bookFloor)
        {
            var filter = Builders<BookFloor>.Filter.Eq(s => s.BookFloorId, bookFloor.BookFloorId);
            await _bookTable.ReplaceOneAsync(filter, bookFloor);
        }
    }
}

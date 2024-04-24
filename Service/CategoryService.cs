using MongoDB.Driver;
using MudBlazorWebApp5.IService;
using MudBlazorWebApp5.Models;

namespace MudBlazorWebApp5.Service
{
    public class CategoryService : ICategoryService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<Category> _categoryTable = null;

        public CategoryService()
        {
            _mongoClient = new MongoClient("mongodb+srv://iftekhar_shakil:iftekhar_shakil@cluster001.w8lyriq.mongodb.net/?retryWrites=true&w=majority&appName=Cluster001");
            _mongoDatabase = _mongoClient.GetDatabase("LibraryDB");
            _categoryTable = _mongoDatabase.GetCollection<Category>("Categories");
        }
        public async Task CreateCategory(Category category)
        {
            await _categoryTable.InsertOneAsync(category);
        }

        public async Task DeleteCategory(string id)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.CategoryId, id);
            await _categoryTable.DeleteOneAsync(filter);
        }

        public async Task<Category> GetCategoryById(string Id)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.CategoryId, Id);
            var cursor = await _categoryTable.FindAsync(filter);
            var result = await cursor.FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var filter = Builders<Category>.Filter.Empty;
            var cursor = await _categoryTable.FindAsync(filter);
            var result = await cursor.ToListAsync();
            return result;
        }

        public async Task UpdateCategory(Category category)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.CategoryId, category.CategoryId);
            var cursor = await _categoryTable.Find(filter).FirstOrDefaultAsync();
            var result = await _categoryTable.ReplaceOneAsync(filter, category);
        }
    }
}

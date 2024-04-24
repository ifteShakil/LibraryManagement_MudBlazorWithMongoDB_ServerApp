using MongoDB.Driver;
using MudBlazorWebApp5.IService;
using MudBlazorWebApp5.Models;

namespace MudBlazorWebApp5.Service
{
    public class SubCategoryService : ISubCategoryService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<SubCategory> _subCategoryTable = null;

        public SubCategoryService()
        {
            _mongoClient = new MongoClient("mongodb+srv://iftekhar_shakil:iftekhar_shakil@cluster001.w8lyriq.mongodb.net/?retryWrites=true&w=majority&appName=Cluster001");
            _mongoDatabase = _mongoClient.GetDatabase("LibraryDB");
            _subCategoryTable = _mongoDatabase.GetCollection<SubCategory>("SubCategories");
        }
        public async Task CreateSubCategory(SubCategory subCategory)
        {
            await _subCategoryTable.InsertOneAsync(subCategory);
        }

        public async Task DeleteSubCategory(string id)
        {
            var filter = Builders<SubCategory>.Filter.Eq(s => s.SubcategoryId, id);
            await _subCategoryTable.DeleteOneAsync(filter);

        }

        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            var filter = Builders<SubCategory>.Filter.Empty;
            var cursor = await _subCategoryTable.FindAsync(filter);
            var result = await cursor.ToListAsync();
            return result;
        }

        public async Task<SubCategory> GetSubCategoryById(string Id)
        {
            var filter = Builders<SubCategory>.Filter.Eq(s => s.SubcategoryId, Id);
            var cursor = await _subCategoryTable.FindAsync(filter);
            var result = await cursor.FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateSubCategory(SubCategory subCategory)
        {
            var filter = Builders<SubCategory>.Filter.Eq(s => s.SubcategoryId, subCategory.SubcategoryId);
            var cursor = await _subCategoryTable.Find(filter).FirstOrDefaultAsync();
            var result = await _subCategoryTable.ReplaceOneAsync(filter, subCategory);
            
        }
    }
}

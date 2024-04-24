using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MudBlazorWebApp5.IService;
using MudBlazorWebApp5.Models;

namespace MudBlazorWebApp5.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IMongoCollection<Author> _AuthorTable;
        private readonly IOptions<DatabaseSettings> _dbSettings;
        //private MongoClient _client = null;
        //private IMongoDatabase _mongoDatabase = null;
        //private IMongoCollection<Author> _AuthorTable = null;

        public AuthorService(IOptions<DatabaseSettings> dbSettings )
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _AuthorTable = mongoDatabase.GetCollection<Author>(dbSettings.Value.AuthorsCollectionName);

            //_client = new MongoClient("mongodb+srv://iftekhar_shakil:iftekhar_shakil@cluster001.w8lyriq.mongodb.net/?retryWrites=true&w=majority&appName=Cluster001");
            //_mongoDatabase = _client.GetDatabase("LibraryDB");
            //_AuthorTable = _mongoDatabase.GetCollection<Author>("Authors");
        }
      


        public async Task CreateAuthor(Author author) =>
            await _AuthorTable.InsertOneAsync(author);

        //Delete Service
        public async Task DeleteAuthor(string id) =>
            await _AuthorTable.DeleteOneAsync(a => a.AuthorId == id);

        //Get by Id Service
        public async Task<Author> GetAuthorById(string id) =>
            await _AuthorTable.Find(a => a.AuthorId == id).FirstOrDefaultAsync();

      

        //Get All Service
        public async Task<IEnumerable<Author>> GetAuthors() => 
            await _AuthorTable.Find(_ => true).ToListAsync();

        //update Service
        public async Task UpdateAuthor(Author author) =>
            await _AuthorTable.ReplaceOneAsync(a => a.AuthorId == author.AuthorId, author);


        //public async Task CreateAuthor(Author author)
        //{
        //    await _AuthorTable.InsertOneAsync(author);
        //    await GetAuthors();
        //}


        //public async Task<Author> GetAuthorById(string id)
        //{
        //    var filter = Builders<Author>.Filter.Eq(a => a.AuthorId, id);
        //    var cursor = await _AuthorTable.FindAsync(filter);
        //    var result = await cursor.FirstOrDefaultAsync();
        //    return result;
        //}

        //public async Task<IEnumerable<Author>> GetAuthors()
        //{
        //    var filter = Builders<Author>.Filter.Empty;
        //    var cursor = await _AuthorTable.FindAsync(filter);
        //    var result = await cursor.ToListAsync();
        //    return result;
        //}


        //public async Task UpdateAuthor(Author author)
        //{
        //    var filter = Builders<Author>.Filter.Eq(a => a.AuthorId, author.AuthorId);
        //    var cursor = await _AuthorTable.Find(filter).FirstOrDefaultAsync();
        //    var res = await _AuthorTable.ReplaceOneAsync(filter, author);
        //}


        //public async Task DeleteAuthor(string id)
        //{
        //    var filter = Builders<Author>.Filter.Eq(a => a.AuthorId, id);
        //    await _AuthorTable.DeleteOneAsync(filter);
        //}
    }
}


using Amazon.Runtime;
using MongoDB.Driver;
using MudBlazorWebApp5.Models;


namespace MudBlazorWebApp5.Account
{
    public class UserService : IUserService
    {
        private MongoClient _client = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<User> _UserTable = null;

        public UserService()
        {
            _client = new MongoClient("mongodb+srv://iftekhar_shakil:iftekhar_shakil@cluster001.w8lyriq.mongodb.net/?retryWrites=true&w=majority&appName=Cluster001");
            _mongoDatabase = _client.GetDatabase("LibraryDB");
            _UserTable = _mongoDatabase.GetCollection<User>("Users");
        }

        public async Task CreateUser(User user)
        {
            await _UserTable.InsertOneAsync(user);
        }

        public async Task DeleteUser(Object id)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, id);
            await _UserTable.DeleteOneAsync(filter);
        }

        public async Task<User> GetUserById(object id)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, id);
            var cursor = await _UserTable.FindAsync(filter);
            var res = await cursor.FirstOrDefaultAsync();
            return res;
        }

        public async Task<User> GetUserNamePassword(string username, string password)
        {
            //string hashedPassword = HashPassword(password);
            var filter = Builders<User>.Filter.Eq(u => u.Username, username) & Builders<User>.Filter.Eq(u => u.Password, password);
            var cursor = await _UserTable.FindAsync(filter);
            var res = await cursor.FirstOrDefaultAsync();
            return res; 
        }
        //private string HashPassword(string password)
        //{
        //    if (password == null)
        //    {
        //        throw new ArgumentNullException(nameof(password), "Password cannot be null.");
        //    }
        //    // You need to implement password hashing logic here
        //    // Example using BCrypt (remember to install the BCrypt.Net package)
        //    return BCrypt.Net.BCrypt.HashPassword(password);
        //}
        

        public async Task<IEnumerable<User>> GetUsers()
        {
            var filter = Builders<User>.Filter.Empty;
            var cursor = await _UserTable.FindAsync(filter);
            var res = await cursor.ToListAsync();
            return res;
        }

        public async Task UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            var cursor = await _UserTable.Find(filter).FirstOrDefaultAsync();
            var res = await _UserTable.ReplaceOneAsync(filter, user);
        }
    }
}

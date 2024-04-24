using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MudBlazorWebApp5.Models
{
    [BsonIgnoreExtraElements]
    public class Author
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string AuthorId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Biography { get; set; } //country of origin, famous for, brief description
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<BookAuthor>? BookAuthor { get; set; } = null!;
        [JsonIgnore]
        public ICollection<UserPreference>? UserPreferences { get; set; } = null!;
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MudBlazorWebApp5.Models
{
    [BsonIgnoreExtraElements]
    public class Author
    {
       
        [BsonRepresentation(BsonType.ObjectId)]
        public string AuthorId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        [Required]
        [StringLength(15, ErrorMessage = "Name length can't be more than 15.")]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        [Range(18, 80, ErrorMessage = "Age must be between 18 and 80.")]
        public int Age { get; set; }
        public string? Biography { get; set; } //country of origin, famous for, brief description
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? IsActive { get; set; }

        //public ICollection<BookAuthor>? BookAuthor { get; set; } = null!;
        //[JsonIgnore]
        //public ICollection<UserPreference>? UserPreferences { get; set; } = null!;
    }
}

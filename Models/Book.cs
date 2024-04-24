using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MudBlazorWebApp5.Models
{
    [BsonIgnoreExtraElements]
    public class Book
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string BookId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public string? CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }

        public string? PublisherId { get; set; }
        [JsonIgnore]
        public Publisher? Publisher { get; set; }
        public DateTime PublishedYear { get; set; }
        public EditionType Edition { get; set; }
        public int? TotalCopies { get; set; }
        public string? Language { get; set; }
        public string? Description { get; set; }
        public decimal? BookPrice { get; set; }

        public bool IsActive { get; set; }
        [NotMapped]
        public IFormFile? Cover { get; set; }
        public string? CoverFileName { get; set; }

        //[JsonIgnore]
        //[NotMapped]
        //public decimal? RefundPrice
        //{
        //    get
        //    {
        //        if (BookPrice.HasValue)
        //        {
        //            return BookPrice * 0.7m; //70% of book price
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        //public string? DDCCode { get; set; }


        //public bool IsDigital { get; set; }
        //[NotMapped]
        //public IFormFile? EBook { get; set; }
        //public bool PublisherAgreement { get; set; }
        //[NotMapped]
        //public IFormFile? AgreementBookCopy { get; set; }

        //public ICollection<BookAuthor>? BookAuthor { get; set; }

        //[JsonIgnore]
        //public List<BookCopy> Copies { get; set; } = new List<BookCopy>();
        //[JsonIgnore]
        //public ICollection<BookReview>? BookReviews { get; set; }
        //[JsonIgnore]
        //public ICollection<BookWishlist>? BookWishlists { get; set; }
        //[JsonIgnore]
        //public ICollection<BorrowedBook>? BorrowedBooks { get; set; }


        //public string? EBookFileName { get; set; }
        //public string? AgreementFileName { get; set; }
    }

    public enum EditionType
    {
        First,
        Second,
        Third,
        // Add more editions as needed
    }
}

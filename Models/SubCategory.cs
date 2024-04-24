using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MudBlazorWebApp5.Models
{
    [BsonIgnoreExtraElements]
    public class SubCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SubcategoryId { get; set; }
        public string? Name { get; set; }
        public string? DDCCode { get; set; }
        public bool IsActive { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }

        //This property will not store data value in the database
        //[BsonIgnoreIfNull]
        //public string CategoryName { get; set;}
    }
}

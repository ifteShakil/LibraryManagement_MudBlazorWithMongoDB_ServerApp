using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MudBlazorWebApp5.Models
{
    [BsonIgnoreExtraElements]
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        //public string UID { get; set; }

        public string? CategoryName { get; set; }
        public string? DDCCode { get; set; }
        public bool IsActive { get; set; }

        //[JsonIgnore]
        //public virtual List<SubCategory> Subcategories { get; set; } = new List<SubCategory>();

        //public Category()
        //{
        //    UID = Guid.NewGuid().ToString().Replace("-","");
        //}

    }
}

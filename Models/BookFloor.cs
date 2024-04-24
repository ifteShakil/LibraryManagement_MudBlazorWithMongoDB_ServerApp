using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MudBlazorWebApp5.Models
{
    [BsonIgnoreExtraElements]
    public class BookFloor
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string BookFloorId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        [Required]
        public string? BookFloorName { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public virtual List<Shelf> Shelves { get; set; } = new List<Shelf>();
    }
}

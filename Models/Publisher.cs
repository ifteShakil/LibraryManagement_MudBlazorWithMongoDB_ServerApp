using MongoDB.Bson.Serialization.Attributes;

namespace MudBlazorWebApp5.Models
{
    [BsonIgnoreExtraElements]
    public class Publisher
    {
        //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string PublisherId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string? CompanyName { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ReasonOfCommunication { get; set; }
        public string? OtherInfo { get; set; }
        public string? Instruction { get; set; }


        
    }


}

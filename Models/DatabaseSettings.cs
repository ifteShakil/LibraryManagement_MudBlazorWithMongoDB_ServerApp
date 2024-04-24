namespace MudBlazorWebApp5.Models
{
    public class DatabaseSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? AuthorsCollectionName { get; set; }
        public string? PublisherCollectionName { get; set; }
        public string? BookFloorsCollectionName { get; set; }
    }
}

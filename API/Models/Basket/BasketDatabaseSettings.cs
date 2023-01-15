namespace API.Models
{
    public class BasketDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string BasketCollectionName { get; set; }
    }
}

namespace Bookstore.Contracts.Settings;

public class AppSettings{
    public bool DeveloperMode { get; set; }
    public JwtSettings JwtSettings { get; set; } = null!;
    public DatabaseSettings DatabaseSettings{ get; set; } = null!;
    public ElasticSearchSettings ElasticsearchSettings { get; set; }
}
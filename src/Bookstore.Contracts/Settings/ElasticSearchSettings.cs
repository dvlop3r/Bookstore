namespace Bookstore.Contracts.Settings;

public class ElasticSearchSettings
{
    public string Url { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string IndexName { get; set; } = null!;
}
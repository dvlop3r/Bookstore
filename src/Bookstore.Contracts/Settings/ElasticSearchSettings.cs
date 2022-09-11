namespace Bookstore.Contracts.Settings;

public class ElasticSearchSettings
{
    public string Url { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public string Index { get; set; }
}
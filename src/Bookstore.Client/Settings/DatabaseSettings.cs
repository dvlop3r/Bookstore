namespace Bookstore.Client.Settings;
    public class DatabaseSettings
    {
        public string AppDbContext { get; set; } = default!;
        public string IdentityDbContext { get; set; } = default!;
        public int MaxRetryCount { get; set; }
        public int Timeout { get; set; }
        public int MaxRetryDelay { get; set; }
    }

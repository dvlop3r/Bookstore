﻿namespace Bookstore.Client.Settings
{
    public class AppSettings
    {
        public DatabaseSettings DbSettings { get; set; } = null!;
        public ElasticSearchSettings ElasticSearchSettings { get; set; } = null!;
        public Services Services { get; set; } = null!;
        public string Storage { get; set; } = null!;
    }
}

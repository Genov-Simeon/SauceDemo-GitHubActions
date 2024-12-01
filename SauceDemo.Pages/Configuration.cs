﻿using Microsoft.Extensions.Configuration;
using System.IO;

namespace SauceDemo.Customizations
{
    public static class Configuration
    {
        private static readonly IConfigurationRoot _config;

        static Configuration()
        {
            var configFile = Directory.GetFiles(Directory.GetCurrentDirectory(), "appsettings.*.json").First();

            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFile, optional: false, reloadOnChange: true)
                .Build();
        }

        public static string Get(string key)
        {
            return _config[key];
        }

        public static string BaseUrl => Get("ApplicationSettings:BaseUrl");
    }
}

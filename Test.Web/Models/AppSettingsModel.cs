using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Web.Models
{
    public class AppSettingsModel
    {
        //private readonly IConfiguration configuration;
        private static AppSettingsModel _appSettings;
        public string BaseUrl { get; set; }
        public string UserAPI { get; set; }
        public string PasswordAPI { get; set; }
        public string UrlApiAuth { get; set; }
        public string UrlApiCustomer { get; set; }

        public AppSettingsModel(IConfiguration config)
        {
            this.BaseUrl = config.GetValue<string>("BaseUrl");
            this.UserAPI = config.GetValue<string>("UserAPI");
            this.PasswordAPI = config.GetValue<string>("PasswordAPI");
            this.UrlApiAuth = config.GetValue<string>("UrlAPIAuth");
            this.UrlApiCustomer = config.GetValue<string>("UrlAPICustomer");

            _appSettings = this;
        }
        public static AppSettingsModel Current
        {
            get
            {
                if (_appSettings == null)
                {
                    _appSettings = GetCurrentSettings();
                }

                return _appSettings;
            }
        }

        public static AppSettingsModel GetCurrentSettings()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();

            var settings = new AppSettingsModel(configuration.GetSection("AppSettings"));
            return settings;
        }
    }
}

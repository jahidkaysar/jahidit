using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.IO;


namespace Reading_Configuration
{
    class Program
    {
        static void Main(string[] args)
        {

            var mySettingsConfig = new MySettingsConfig();
            new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddUserSecrets<Program>()
               .AddEnvironmentVariables().Build().GetSection("MySettings").Bind(mySettingsConfig);

            Console.WriteLine("Setting from appsettings.json: " + mySettingsConfig.AccountName);
            Console.WriteLine("Setting from secrets.json: " + mySettingsConfig.ApiSecret);
            Console.WriteLine("Connection string: " + new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddUserSecrets<Program>()
               .AddEnvironmentVariables().Build().GetConnectionString("DefaultConnection"));

            Console.ReadKey();
        }



    }
}

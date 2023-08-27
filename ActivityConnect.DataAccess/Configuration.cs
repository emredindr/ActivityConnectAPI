using Microsoft.Extensions.Configuration;

namespace ActivityConnect.DataAccess;

static class Configuration
{
    static public string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            try
            {
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../ActivityConnect.API"));
                configurationManager.AddJsonFile("appsettings.json");
            }
            catch
            {
                configurationManager.AddJsonFile("appsettings.json");
            }

            return configurationManager.GetConnectionString("SqlServer");
        }
    }

}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PumpItUp.DAL.Configuration
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("D://WebProjectDotNetUni//PumpItUp//PumpItUp.DAL//appsettings.json")
                .Build();

            DbContextOptionsBuilder<AppDbContext> optionsBuilder = new();
            string? connectionString = configuration.GetConnectionString("DbConnectionString");

            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
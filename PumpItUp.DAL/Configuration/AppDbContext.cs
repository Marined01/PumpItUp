using Microsoft.EntityFrameworkCore;
using PumpItUp.BLL.Models;
using PumpItUp.DAL.Models;

namespace PumpItUp.DAL.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<BankData> BankData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasOne(u => u.BankData)
                .WithOne(b => b.User)
                .HasForeignKey<BankData>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
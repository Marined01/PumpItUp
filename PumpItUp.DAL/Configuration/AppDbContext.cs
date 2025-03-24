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
    public DbSet<Post> Posts { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Following> Followings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.BankData)
            .WithOne(b => b.User)
            .HasForeignKey<BankData>(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // modelBuilder.Entity<Post>()
        //         .HasMany(p => p.Attachments)
        //         .WithOne(a => a.Post)
        //         .HasForeignKey(a => a.PostId)
        //         .OnDelete(DeleteBehavior.Cascade);

        // modelBuilder.Entity<User>()
        // .HasOne(u => u.Role)
        // .WithMany(r => r.Users)
        // .HasForeignKey(u => u.RoleId)
        // .OnDelete(DeleteBehavior.Cascade);

        // modelBuilder.Entity<User>()
        // .HasMany(u => u.Followers)
        // .WithOne(f => f.Following)
        // .HasForeignKey(f => f.FollowingId)   
    }
}
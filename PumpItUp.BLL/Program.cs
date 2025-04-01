using Microsoft.EntityFrameworkCore;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.Configuration;
using Serilog;
var logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PumpItUpLogs", "log-.txt");

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=pumpitup_db;Username=postgres;Password=root;SslMode=Disable"));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AttachmentService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<FollowingService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
using Microsoft.EntityFrameworkCore;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.Configuration;
using Serilog;
using DotNetEnv;

var logPath = Path.combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PumpItUpLogs", "log-.txt");

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Завантаження .env
Env.Load();

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__PumpItUpDb") ??
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

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

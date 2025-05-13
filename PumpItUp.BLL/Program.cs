using Microsoft.EntityFrameworkCore;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.Repositories;
using Serilog;
using Microsoft.Extensions.FileProviders;
using System.IO;
using DotNetEnv;

var logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PumpItUpLogs", "log-.txt");

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

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

// Register repositories
builder.Services.AddScoped<ExerciseSetRepository>();

// Register services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AttachmentService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<FollowingService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<ExerciseService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Configure static file middleware for serving images from the storage directory
var imagesFolder = Path.Combine("D:", "university", "6 semester", "software engineering", "WebProject", "PumpItUp.DAL", "storage", "images");
if (!Directory.Exists(imagesFolder))
{
    Directory.CreateDirectory(imagesFolder);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagesFolder),
    RequestPath = "/images"
});

app.UseRouting();

// Use session before authorization
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
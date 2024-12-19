using AsyncLab.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Lägg till denna Kestrel-konfiguration
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    // Begränsa antalet samtidiga anslutningar till ett lågt antal
    serverOptions.Limits.MaxConcurrentConnections =10;
    
    // Konfigurera thread pool för att begränsa antalet worker threads
    ThreadPool.SetMinThreads(5, 5);
    ThreadPool.SetMaxThreads(5, 5);
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
)
.WithStaticAssets();


app.Run();

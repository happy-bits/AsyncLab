using AsyncLab.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Lägg till denna Kestrel-konfiguration
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    ThreadPool.SetMinThreads(5, 5); // denna krävs annars kommer systemet starta med flera trådan än 5 och sedan trappa ner
    ThreadPool.SetMaxThreads(5, 5);
    
    // Aktivera HTTP/2 - annars sättre webläsaren en begränsning hur många samtidiga anslutningar som tillåt per domän
    serverOptions.ListenLocalhost(5001, options =>
    {
        options.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
        options.UseHttps();  // HTTP/2 kräver HTTPS
    });
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

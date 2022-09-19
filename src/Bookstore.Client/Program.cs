using Bookstore.Client;
using Bookstore.Client.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AppSettings>(builder.Configuration.Get<AppSettings>());
var appSettings = builder.Configuration.Get<AppSettings>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureHttp();
builder.Services.ConfigureIOptions(builder.Configuration);
builder.Services.ConfigureStorageServices(builder.Configuration);
builder.Services.ConfigureMapster();
builder.Services.ConfigureElasticsearch(builder.Configuration);
builder.Services.AddIdentityDbContext(appSettings.DbSettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Bookstore.Api;
using Bookstore.Application;
using Bookstore.Contracts.Settings;
using Bookstore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<AppSettings>(builder.Configuration.Get<AppSettings>());
var appSettings = builder.Configuration.Get<AppSettings>();

builder.Services.AddPresentation(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration, appSettings);
builder.Services.AddApplication(appSettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    // First approach to handle exceptions
    app.UseExceptionHandler("/error");

    // Third approach to handle exceptions
    //app.UseMiddleware<ErrorHandlingMiddleware>(); 

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using Bookstore.Api;
using Bookstore.Application;
using Bookstore.Contracts.Settings;
using Bookstore.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

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
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}
    // First approach to handle exceptions
    app.UseExceptionHandler("/error");

    // Third approach to handle exceptions
    //app.UseMiddleware<ErrorHandlingMiddleware>(); 

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

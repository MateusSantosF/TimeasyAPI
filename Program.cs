using FastEndpoints.Security;
using FastEndpoints.Swagger;
using timeasy_api.src.Contexts;
using timeasy_api.src.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints()
   .AddJWTBearerAuth("TokenSigningKey")
   .AddAuthorization();

builder.Services.RegisterDependencies();

builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "Timeasy API";
        s.DocumentName = "TimeasyAPI";
        s.Version = "v1";
    };
});

var appSettings = new AppSettings();
builder.Configuration.GetSection("AppSettings").Bind(appSettings);


var connectionString = builder.Configuration.GetConnectionString(nameof(TimeasyDbContext)) ?? throw new Exception("Database ConnectionString not found.");

builder.Services.AddDbContext<TimeasyDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

app.UseFastEndpoints()
    .UseAuthentication()
    .UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

app.Run();
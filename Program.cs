using FastEndpoints.Security;
using FastEndpoints.Swagger;
using timeasy_api.src.Contexts;
using timeasy_api.src.Core;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder();


var secretJwtKey = builder.Configuration.GetSection("AppSettings:TokenConfiguration:SecretJwtKey").Value ?? throw new Exception("JWTSecret not found."); ;

builder.Services.AddFastEndpoints()
   .AddJWTBearerAuth(secretJwtKey)
   .AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder => builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
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



var connectionString = builder.Configuration.GetConnectionString(nameof(TimeasyDbContext)) ?? throw new Exception("Database ConnectionString not found.");

builder.Services.AddDbContext<TimeasyDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

app.UseCors("AllowLocalhost3000");

app.UseFastEndpoints(c => c.Serializer.Options.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .UseAuthentication()
    .UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

app.Run();
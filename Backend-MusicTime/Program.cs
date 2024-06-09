using Backend_MusicTime.Musician.Application.Internal.CommandServices;
using Backend_MusicTime.Musician.Application.Internal.QueryServices;
using Backend_MusicTime.Musician.Domain.Repositories;
using Backend_MusicTime.Musician.Domain.Services;
using Backend_MusicTime.Musician.Infrastructure.Persistence.EFC.Repositories;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Review.Infrastructure.Persistence.EFC.Repositories;
using Backend_MusicTime.Shared.Domain.Repositories;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_MusicTime.Shared.Interfaces.ASP.Configuration;


using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;













var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Backend-MusicTime",
                Version = "v1",
                Description = "Backend Music Time API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "codex",
                    Email = "codex@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    
// Musician bounded context injection configuration
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
//builder.Services.AddScoped<IArtistCommandService, ArtistCommandService>();
builder.Services.AddScoped<IArtistQueryService, ArtistQueryService>();

builder.Services.AddScoped<IBandRepository, BandRepository>();
builder.Services.AddScoped<ICommentRepository,CommentRepository>();
builder.Services.AddScoped<IPuntuationRepository,PuntuationRepository>();


var app = builder.Build();

// Verify Database Objects area Created

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
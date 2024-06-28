using Backend_MusicTime.Contracts.Application.Internal.CommandServices;
using Backend_MusicTime.Contracts.Application.Internal.QueryServices;
using Backend_MusicTime.Contracts.Domain.Repositories;
using Backend_MusicTime.Contracts.Domain.Services;
using Backend_MusicTime.Contracts.Infrastructure.Persistence.EFC.Repositories;
using Backend_MusicTime.Customer.Application.Internal.CommandServices;
using Backend_MusicTime.Customer.Application.Internal.QueryServices;
using Backend_MusicTime.Customer.Domain.Repositories;
using Backend_MusicTime.Customer.Domain.Services;
using Backend_MusicTime.Customer.Infrastructure.Persistence.EFC.Repositories;
using Backend_MusicTime.Customer.Interfaces.ACL;
using Backend_MusicTime.Customer.Interfaces.ACL.Services;
using Backend_MusicTime.Enterprise.Application.Internal.CommandServices;
using Backend_MusicTime.Enterprise.Application.Internal.QueryServices;
using Backend_MusicTime.Enterprise.Domain.Repositories;
using Backend_MusicTime.Enterprise.Domain.Services;
using Backend_MusicTime.Enterprise.Infrastructure.Persistence.EFC.Repositories;
using Backend_MusicTime.Enterprise.Interfaces.ACL;
using Backend_MusicTime.Enterprise.Interfaces.ACL.Services;
using Backend_MusicTime.IAM.Application.Internal.CommandServices;
using Backend_MusicTime.IAM.Application.Internal.OutboundServices;
using Backend_MusicTime.IAM.Application.Internal.QueryServices;
using Backend_MusicTime.IAM.Domain.Repositories;
using Backend_MusicTime.IAM.Domain.Services;
using Backend_MusicTime.IAM.Infrastructure.Hashing.BCrypt.Services;
using Backend_MusicTime.IAM.Infrastructure.Persistence.EFC.Repositories;
using Backend_MusicTime.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using Backend_MusicTime.IAM.Infrastructure.Tokens.JWT.Configuration;
using Backend_MusicTime.IAM.Infrastructure.Tokens.JWT.Services;
using Backend_MusicTime.IAM.Interfaces.ACL;
using Backend_MusicTime.IAM.Interfaces.ACL.Services;
using Backend_MusicTime.Musician.Application.Internal.CommandServices;
using Backend_MusicTime.Musician.Application.Internal.QueryServices;
using Backend_MusicTime.Musician.Domain.Repositories;
using Backend_MusicTime.Musician.Domain.Services;
using Backend_MusicTime.Musician.Infrastructure.Persistence.EFC.Repositories;
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
                TermsOfService = new Uri("https://music-time.com/tos"),
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
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            } 
        });
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedAllPolicy",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Musician bounded context injection configuration
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IArtistCommandService, ArtistCommandService>();
builder.Services.AddScoped<IArtistQueryService, ArtistQueryService>();

// Customers Bounded Context Injection Configuration
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerCommandService, CustomerCommandService>();
builder.Services.AddScoped<ICustomerQueryService, CustomerQueryService>();
builder.Services.AddScoped<ICustomersContextFacade, CustomersContextFacade>();

// Enterprise Bounded Context Injection Configuration
builder.Services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
builder.Services.AddScoped<IEnterpriseCommandService, EnterpriseCommandService>();
builder.Services.AddScoped<IEnterpriseQueryService, EnterpriseQueryService>();
builder.Services.AddScoped<IEnterpriseContextFacade, EnterpriseContextFacade>();

// IAM Bounded Context Injection Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerCommandService, CustomerCommandService>();
builder.Services.AddScoped<ICustomerQueryService, CustomerQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

// Add this line to register your ContractCommandService
builder.Services.AddScoped<IContractCommandService, ContractCommandService>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IContractQueryService, ContractQueryService>();

// Add this line to register your User
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();




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
// Apply CORS Policy
app.UseCors("AllowedAllPolicy");

// Add Authorization Middleware to the Request Pipeline

//app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
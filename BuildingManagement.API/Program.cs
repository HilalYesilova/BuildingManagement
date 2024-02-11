using BuildingManagement.API.Extensions;
using BuildingManagement.Entity;
using BuildingManagement.Repository;
using BuildingManagement.Repository.Repository.TokenRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDIContainer();
builder.Services.AddScoped<CreateDefaultSettings>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Building Management API", Version = "v1" });
});
builder.Services.AddAutoMapper(typeof(Program)); // IMapper
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"),
        sqloptions => { sqloptions.MigrationsAssembly("BuildingManagement.Repository"); });
});

builder.Services.AddIdentity<User, UserRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddAuthentication(options =>
{
    //schema
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    var signatureKey = builder.Configuration.GetSection("TokenOptions")["SignatureKey"]!;
    var issuer = builder.Configuration.GetSection("TokenOptions")["Issuer"]!;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = true,
        ValidIssuer = issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signatureKey))
    };
});

builder.Services.AddAuthorization();

#region Versioning
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});
#endregion


var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var settingsService = serviceScope.ServiceProvider.GetRequiredService<CreateDefaultSettings>();

    // Default Admin Oluþturma
    settingsService.CreateDefaultAdminAsync().GetAwaiter().GetResult();

    // Default Bina Oluþturma
    settingsService.CreateDefaultBuildingAsync().GetAwaiter().GetResult();

    // Default Ödeme Tipleri Oluþturma
    settingsService.CraeteDefaultPaymentTypesAsync().GetAwaiter().GetResult();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Building Management API V1");
    });

}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

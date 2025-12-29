using Microsoft.EntityFrameworkCore;
using RentVault.Api.Data;
using RentVaultAPI.Models;
using RentVaultAPI.Repositories;
using RentVaultAPI.Repositories.Interfaces;
using RentVaultAPI.Services;
using RentVaultAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"DB = {conn}");
// DbContext
builder.Services.AddDbContext<RentVaultDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RentVaultDbContext>();

    if (!db.Users.Any())
    {
        db.Users.Add(new User
        {
            Email = "test@rentvault.com",
            HashPassword = "hashed-password"
        });

        db.SaveChanges();
    }
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

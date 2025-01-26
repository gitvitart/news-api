using Microsoft.AspNetCore.DataProtection;
using NewsAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//- DB_HOST = postgres
//- POSTGRES_DB = newsdb
//- POSTGRES_USER = postgres
//- POSTGRES_PASSWORD = 123Secret_a

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB");
var dbUser = Environment.GetEnvironmentVariable("POSTGRES_USER");
var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

var connectionString = $"Server = {dbHost};Port=5432;Database={dbName};User Id ={dbUser};Password={dbPassword}";
builder.Services.AddScoped(provider => new DataContext(connectionString));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

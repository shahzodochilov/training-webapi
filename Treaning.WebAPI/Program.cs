
//-->  Services
using Microsoft.EntityFrameworkCore;
using Treaning.WebAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//--> Database
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLLocalDb");
builder.Services.AddDbContext<AppDbContext>(dbOptios => dbOptios.UseNpgsql(connectionString));

//--> Middlewares
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

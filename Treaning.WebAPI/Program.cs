
//-->  Services
using Microsoft.EntityFrameworkCore;
using Treaning.WebAPI.Data;
using Treaning.WebAPI.Interfaces.Repositories;
using Treaning.WebAPI.Interfaces.Services;
using Treaning.WebAPI.Repositories;
using Treaning.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//--> Database
var connectionString = builder.Configuration.GetConnectionString("PostgreSqlLocalDb");
builder.Services.AddDbContext<AppDbContext>(dbOptios => dbOptios.UseNpgsql(connectionString));

//--> Repository Reletions
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

//--> Service Reletions
builder.Services.AddScoped<IStudentService, StudentService>();

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

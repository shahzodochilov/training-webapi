
//-->  Services
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Treaning.WebAPI.Data;
using Serilog;
using Treaning.WebAPI.Interfaces.Repositories;
using Treaning.WebAPI.Interfaces.Services;
using Treaning.WebAPI.Repositories;
using Treaning.WebAPI.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//--> Database
var connectionString = builder.Configuration.GetConnectionString("PostgreSqlLocalDb");
builder.Services.AddDbContext<AppDbContext>(dbOptions =>
{
    dbOptions.UseNpgsql(connectionString);
    dbOptions.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration)=>
                loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

//--> Repository Reletions
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

//--> Service Reletions
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAccountService, AccountService>();

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

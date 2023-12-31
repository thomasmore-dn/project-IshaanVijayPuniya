using aspnet.Contexts;
using aspnet.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepo, MysqlRepo>();

String _connectionstring = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<SneakerContext>(opt => opt.UseMySql(_connectionstring, ServerVersion.AutoDetect(_connectionstring)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// app Environemnt is set to Development because it is great for Testing.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

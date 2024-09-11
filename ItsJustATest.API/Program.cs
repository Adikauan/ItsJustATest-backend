using Microsoft.EntityFrameworkCore;
using ItsJustATest.Application.Commands.Create;
using ItsJustATest.Domain.Interfaces;
using ItsJustATest.Infrastructure.EntityFramework.Context;
using ItsJustATest.Infrastructure.EntityFramework.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg => cfg.AllowNullCollections = true);
string? SqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SampleDbContext>(options => options.UseSqlServer(SqlConnection)
                                            , ServiceLifetime.Scoped);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCommand).Assembly));
builder.Services.AddAutoMapper(typeof(CreateCommand).Assembly);

//builder.Services.AddScoped<IBaseRepository<T>, BaseRepository<T>();

builder.Services.AddScoped<ISampleRepository, SampleRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

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

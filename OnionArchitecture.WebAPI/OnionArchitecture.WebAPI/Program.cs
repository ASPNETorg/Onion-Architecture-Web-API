using DomainLayer.Data;
using DomainLayer.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Contracts;
using RepositoryLayer.Repositories;
using ServiceLayer.Contracts;
using ServiceLayer.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddControllers();

#region [- DependencyInjection -]
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomService<Student>, StudentService>();
builder.Services.AddScoped<ICustomService<DomainLayer.Models.DomainModels.Results>, ResultService>();
builder.Services.AddScoped<ICustomService<Departments>, DepartmentsService>();
builder.Services.AddScoped<ICustomService<SubjectGpas>, SubjectGpasService>(); 
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

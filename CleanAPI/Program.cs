using System.Text.Json.Serialization;
using Clean.Core.Repositories;
using Clean.Core.Services;
using Clean.Data;
using Clean.Data.Repositories;
using Clean.Service;
using Clean.API.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoriesRepositories, CategoriesRepositories>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

builder.Services.AddScoped<IInstructorsRepositories, InstructorsRepositories>();
builder.Services.AddScoped<IInstructorsService, InstructorsService>();

builder.Services.AddScoped<ICoursesRepositories, CoursesRepositories>();
builder.Services.AddScoped<ICoursesService, CoursesService>();

builder.Services.AddScoped<IStudentsRepositories, StudentsRepositories>();
builder.Services.AddScoped<IStudentsService, StudentsService>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

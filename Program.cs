using Gestion_etudiant.Repositories;
using Gestion_etudiant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI (for development or all environments)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the database connection
builder.Services.AddDbContextPool<StudentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDBConnection")));

// Add scoped repositories for dependency injection
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

// Set application URL
builder.WebHost.UseUrls("http://localhost:5000");

var app = builder.Build();

// Configure the HTTP request pipeline.
// Enable Swagger only for development environments (optional)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable serving static files (for CSS, JS, etc.)
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable authorization middleware
app.UseAuthorization();

// Map controller routes (default route)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Start the application
app.Run();

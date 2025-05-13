using Microsoft.EntityFrameworkCore;
using NurserySystem.Application.Services;
using NurserySystem.Domain.Interfaces;
using NurserySystem.Infrastructure.Data;
using NurserySystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NurseryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddSpaStaticFiles(configuration =>
// {
//     configuration.RootPath = "ClientApp/dist";
// });

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IChildRepository, ChildRepository>();
builder.Services.AddScoped<IChildService, ChildService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseCors("AllowAngularApp");

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting(); // <-- This is required BEFORE MapControllers()

//app.UseAuthorization();

// app.UseStaticFiles();
// app.UseSpaStaticFiles(); // Serve Angular static files in production
app.MapControllers(); 
app.MapFallbackToFile("index.html");

// app.UseSpa(spa =>
// {
//     spa.Options.SourcePath = "ClientApp"; // Angular project root

//     if (app.Environment.IsDevelopment())
//     {
//         // Proxy requests to Angular dev server for live reload
//         spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
//     }
// });

app.Run();
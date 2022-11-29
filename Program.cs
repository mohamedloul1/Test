using ContosoPizaa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ContosoPizaa.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder. Services . AddRazorPages ();
builder.Services.AddDbContext<ContosoPizzaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ContosoPizza")));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

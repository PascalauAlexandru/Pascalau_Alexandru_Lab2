using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pascalau_Alexandru_Lab2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyModel;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Pascalau_Alexandru_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pascalau_Alexandru_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Pascalau_Alexandru_Lab2Context' not found.")));
builder.Services.AddDbContext<LibraryIdentityContex>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Pascalau_Alexandru_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Pascalau_Alexandru_Lab2Context' not found")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LibraryIdentityContex>();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

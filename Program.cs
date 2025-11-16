using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pascalau_Alexandru_Lab2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyModel;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});


builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Publishers", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Categories", "AdminPolicy");
});
builder.Services.AddDbContext<Pascalau_Alexandru_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pascalau_Alexandru_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Pascalau_Alexandru_Lab2Context' not found.")));
builder.Services.AddDbContext<LibraryIdentityContex>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Pascalau_Alexandru_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Pascalau_Alexandru_Lab2Context' not found")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() 
    .AddEntityFrameworkStores<LibraryIdentityContex>();
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

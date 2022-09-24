using Frases_Lowsedo.Contracts.IConfiguration;
using Frases_Lowsedo.Contracts.IRepositories;
using Frases_Lowsedo.Model;
using Frases_Lowsedo.Persistence.Configuration;
using Frases_Lowsedo.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FrasesLowsedoDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<FrasesLowsedoDBContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

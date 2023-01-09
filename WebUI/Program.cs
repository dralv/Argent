using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Account;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Entity;
using Infra.Data.Identity;
using Infra.Data.Repositorios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("Principal");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IDespesaService, DespesaService>();
builder.Services.AddScoped<IDespesaRepository, DespesaRepository>();
builder.Services.AddScoped<ICategoriaDespesaService, CategoriaDespesaService>();
builder.Services.AddScoped<ICategoriaDespesaRepository, CategoriaDespesaRepository>();
builder.Services.AddScoped<IReceitaService, ReceitaService>();
builder.Services.AddScoped<IReceitaRepository, ReceitaRepository>();
builder.Services.AddScoped<ICategoriaReceitaService, CategoriaReceitaService>();
builder.Services.AddScoped<ICategoriaReceitaRepository, CategoriaReceitaRepository>();
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
builder.Services.AddScoped<IAuthenticate, AuthenticateService>();

builder.Services.AddAutoMapper(typeof(DespesaProfile));
builder.Services.AddAutoMapper(typeof(CategoriaDespesaProfile));
builder.Services.AddAutoMapper(typeof(ReceitaProfile));
builder.Services.AddAutoMapper(typeof(CategoriaReceitaProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
SeedUserRoles(app);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedUserRoles(IApplicationBuilder app)
{
    using(var serviceScope = app.ApplicationServices.CreateScope())
    {
        var seed = serviceScope.ServiceProvider.GetService<ISeedUserRoleInitial>();

        seed.SeedUser();
        seed.SeedRoles();
    }
}
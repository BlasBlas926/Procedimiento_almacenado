using Microsoft.EntityFrameworkCore;
using ProductosMVC.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CategoriasDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Conexion") ?? throw new InvalidOperationException("Connection string 'CategoriasDbContext' not found.")));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categorias}/{action=Index}/{id?}");

app.Run();

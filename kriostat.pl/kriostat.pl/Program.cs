using Kriostat.Lib.BookRepositories.RepositoryDB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<MyContext>(o=>o.UseMySQL("server=mariadb11.iq.pl; port=3306; database=cybertrick_wiola; user=cybertrick_wiola; password=7PIAyKzI2lh7sSuBJVTK; Persist Security Info=False; Connect Timeout=300;Convert Zero Datetime=true;Character Set=utf8"));

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
app.UseSession();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
    );

app.Run();

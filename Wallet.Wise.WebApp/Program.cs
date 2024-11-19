using Microsoft.EntityFrameworkCore;
using Wallet.Wise.BLL.Services;
using Wallet.Wise.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WalletWiseContext>(options => options.UseSqlite("Data source=../WalletWiseDb.sql"));
builder.Services.AddScoped<CategoryServices>();

//Pipe-line http request
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categories}/{action=Index}/{id?}");

app.Run();
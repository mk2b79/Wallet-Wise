using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wallet.Wise.BLL.Services;
using Wallet.Wise.Common.Mappings;
using Wallet.Wise.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Add DbContext Injection
builder.Services.AddDbContext<WalletWiseContext>(options => options.UseSqlite("Data source=../WalletWiseDb.sql"));
//
// builder.Services.AddAuthorization();
// builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
//Add AutoMapper Injection
builder.Services.AddAutoMapper(typeof(MappingProfile));
//BLL Services Injection
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
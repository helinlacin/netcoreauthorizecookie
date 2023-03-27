using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opitons =>
{
    opitons.Cookie.Name = "NetCoreMvc.Auth";
    //giridi�imiz kullan�c� bilgisi yoksa nereye y�nlendirmesi gerekti�ini s�yleyecek;
    opitons.LoginPath = "/Login/Index";
    //kullan�c�n�n yetkili olmas�n� isteyelim yetkisiz kullan�c�y� buryay y�nlendirir;
    opitons.AccessDeniedPath = "/Login/Index"; 
});

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
//kullan�c�y� kontrol eder.
app.UseAuthentication();    
//yetkileri kontrol eder.
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

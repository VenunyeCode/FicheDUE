using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.
	AddRazorPages().
	AddCookieTempDataProvider();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(2);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

builder.Services.AddTransient<HttpContextAccessor>();
builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
	.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
	{
		options.Cookie.Name = "TestCookie";
		options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
		options.LoginPath = "/Home/Login";
		options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
		options.Cookie.SameSite = SameSiteMode.Strict;
	});

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
app.MapDefaultControllerRoute();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Login}/{action=Index}/{id?}"
);

app.Run();

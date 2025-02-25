using armadieti2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// alwaysmigrate to the newst database schema on startup
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
app.UseHttpsRedirection();

// Listen on the PORT environment variable propvided by railway
if (builder.Environment.IsProduction() && builder.Configuration.GetValue<int?>("PORT") is not null)
    builder.WebHost.UseUrls($"https://*:{builder.Configuration.GetValue<int>("PORT")}");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

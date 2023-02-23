using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OnlineShop.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddAntDesign();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin());

app.MapBlazorHub();
app.MapFallbackToPage("/Index");


app.Run();

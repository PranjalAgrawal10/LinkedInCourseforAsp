using System.Text.Json;
using ConsoleCrafts.Models;
using ConsoleCrafts.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<JsonFileProductsService>();
builder.Services.AddServerSideBlazor();

builder.Services.AddControllers();

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

// for older version
// app.UseEndpoints(endpoint =>
// {
//     endpoint.MapRazorPages();
//     endpoint.MapGet("/products", (context) =>
//     {
//         var products = app.Services.GetService<JsonFileProductsService>().GetProducts();
//         var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
//         return context.Response.WriteAsync(json);
//     });
// });


app.MapRazorPages();

// newer version
// app.MapGet("/products", (context) => 
// {
//     var products = app.Services.GetService<JsonFileProductsService>().GetProducts();
//     var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
//     return context.Response.WriteAsync(json);
// });

app.MapControllers();
app.MapBlazorHub();

app.Run();
using System.Text.Json;
using ConsoleCrafts.Models;

namespace ConsoleCrafts.Services;

public class JsonFileProductsService
{
    public JsonFileProductsService(IWebHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
    }

    public IWebHostEnvironment WebHostEnvironment { get; set; }
    
    private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

    public IEnumerable<Product> GetProducts()
    {
        using var jsonFileReader = File.OpenText(JsonFileName);
        return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
    }
}
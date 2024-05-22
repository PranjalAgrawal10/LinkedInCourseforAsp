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

    public void AddRating(string productId, int rating)
    {
        var products = GetProducts();

        var query = products.First(x => x.Id == productId);
        if (query != null)
        {
            if (query.Ratings == null)
            {
                query.Ratings = new[] { rating };
            }
            else
            {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
            }
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(new Utf8JsonWriter(outputStream, new JsonWriterOptions()
                {
                    SkipValidation = true,
                    Indented = true
                }), products);
            }
        }
        else
        {
            throw new Exception("product for found associated to product id");
        }
    }
}
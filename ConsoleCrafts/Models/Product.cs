using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleCrafts.Models;

public class Product
{
    [JsonPropertyName("Id")]
    public string Id { get; set; }
    
    [JsonPropertyName("Maker")]
    public string Maker { get; set; }
    
    [JsonPropertyName("img")]
    public string Image { get; set; }
    
    [JsonPropertyName("Title")]
    public string Title { get; set; }
    
    [JsonPropertyName("Description")]
    public string Description { get; set; }
    
    [JsonPropertyName("Ratings")]
    public int[] Ratings { get; set; }

    public override string ToString() => JsonSerializer.Serialize<Product>(this);
}
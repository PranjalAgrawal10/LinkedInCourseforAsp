using ConsoleCrafts.Models;
using ConsoleCrafts.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConsoleCrafts.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public JsonFileProductsService ProductService;
    public IEnumerable<Product> Products { get; private set; }

    public IndexModel(ILogger<IndexModel> logger, JsonFileProductsService productsService)
    {
        ProductService = productsService;
        _logger = logger;
    }
    
    public void OnGet()
    {
        Products = ProductService.GetProducts();
    }
}
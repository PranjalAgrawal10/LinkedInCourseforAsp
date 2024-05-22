using ConsoleCrafts.Models;
using ConsoleCrafts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleCrafts.Controller;


[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    public JsonFileProductsService ProductsService { get; set; }

    public ProductsController(JsonFileProductsService productsService)
    {
        this.ProductsService = productsService;
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return ProductsService.GetProducts();
    }

}
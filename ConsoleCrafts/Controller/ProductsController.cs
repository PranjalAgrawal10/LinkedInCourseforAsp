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

    // [HttpPatch]
    [Route("Rate")]
    [HttpGet]
    public ActionResult Get([FromQuery]string ProductId, [FromQuery]int Rating)
    {
        ProductsService.AddRating(ProductId, Rating);
        return Ok();
    }

}
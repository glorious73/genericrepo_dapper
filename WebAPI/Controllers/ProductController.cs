using Application.Dto;
using Application.Logic.ProductService;
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepo_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto productDto)
    {
        int productsCreated = await _service.Create(productDto);
        return Created("", new { result = (productsCreated > 0) });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDto productDto)
    {
        int productsEdited = await _service.Update(id, productDto);
        return Ok(new { result = (productsEdited > 0) });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Product product = await _service.GetById(id);
        return Ok(new { product });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = (await _service.GetAll()).ToList();
        int totalItems = await _service.CountAll(); // Note that this can be paginated
        return Ok(new { products, totalItems});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool result = await _service.Delete(id);
        return Ok(new { message = (result) ? "Product record was deleted." : "An error occured." });
    }
}
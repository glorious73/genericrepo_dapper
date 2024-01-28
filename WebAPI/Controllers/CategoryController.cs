using Application.Dto;
using Application.Logic.CategoryService;
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepo_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
    {
        int categoriesCreated = await _service.Create(categoryDto);
        return Created("", new { result = (categoriesCreated > 0) });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CategoryDto categoryDto)
    {
        int categoriesEdited = await _service.Update(id, categoryDto);
        return Ok(new { result = (categoriesEdited > 0) });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Category category = await _service.GetById(id);
        return Ok(new { category });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = (await _service.GetAll()).ToList();
        int totalItems = await _service.CountAll(); // Note that this can be paginated
        return Ok(new { categories, totalItems});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool result = await _service.Delete(id);
        return Ok(new { message = (result) ? "Category record was deleted." : "An error occured." });
    }
}
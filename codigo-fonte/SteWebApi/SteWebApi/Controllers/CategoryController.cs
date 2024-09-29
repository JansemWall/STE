using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SteWebApi.DtoModels;
using SteWebApi.Model;

namespace SteWebApi.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]

public class CategoryController : ControllerBase
{
    private readonly MongoDbContext _MongoDbContext;

    public CategoryController(MongoDbContext context)
    {
        _MongoDbContext = context;
    }

    [HttpPost("Create")]
    public async Task<ActionResult> Create([FromBody] CategoryCreateDto model)
    {
        var category = new Category
        {
            Name = model.Name
        };
        await _MongoDbContext.Category.InsertOneAsync(category);
        return Ok(model);
    }

    [HttpPut("Edit/{id}")]
    public async Task<ActionResult> UpdateCategoryName(string id, [FromBody] CategoryCreateDto newCategory)
    {
        var category = await _MongoDbContext.Category.Find(c => c.Id == id).FirstOrDefaultAsync();
        if (category == null) return NotFound();
        category.Name = newCategory.Name;
        await _MongoDbContext.Category.ReplaceOneAsync(c => c.Id == id, category);
        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        await _MongoDbContext.Items.DeleteManyAsync(x => x.CategoryId == id);

        
        var category = await _MongoDbContext.Category.FindOneAndDeleteAsync(x => x.Id == id);
        if (category == null) NotFound();
        return NoContent();
    }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult> GetById(string id)
    {
        var category = await _MongoDbContext.Category.Find(c => c.Id == id).FirstOrDefaultAsync();
        if (category == null) return NotFound();

        var items = await _MongoDbContext.Items.Find(i => i.CategoryId == id).ToListAsync();
        category.Items = items; 

        
        return Ok(category);
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult> GetAll()
    {
        var model = await _MongoDbContext.Category.Find(_ => true).ToListAsync();
        return Ok(model);
    }
}
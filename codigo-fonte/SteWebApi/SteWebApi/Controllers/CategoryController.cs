using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SteWebApi.DtoModels;
using SteWebApi.Model;
//using @swagger_auto_schema

namespace SteWebApi.Controllers;

[Authorize]
[Route("api/category")]
[ApiController]

public class CategoryController : ControllerBase
{
    private readonly MongoDbContext _MongoDbContext;
    const string controllerName = "Category";
    public CategoryController(MongoDbContext context)
    {
        _MongoDbContext = context;
    }

    [HttpPost()]
    public async Task<ActionResult> Create([FromBody] CategoryCreateDto newCategory)
    {
    
        var existingitem = await _MongoDbContext.Category
            .Find(x => x.Name == newCategory.Name)
            .FirstOrDefaultAsync();

        if (existingitem != null)
        {
            return BadRequest("Já existe uma categoria com o mesmo nome.");
        }
        var category = new Category
        {
            Name = newCategory.Name
        };
        await _MongoDbContext.Category.InsertOneAsync(category);
        //Criar categoria.

        var log = new Log
        {
            Date = DateTime.Now,
            UserName = User.Identity.Name,//pega o usuário logado.
            ElementId = category.Id, //importante verificar se o insert de categoria cai no banco antes de puxar o id.
            ElementName = category.Name,
            Type = controllerName,
            OldValue = "Categoria criada.",
            Note = "Categoria criada."
        };
        await _MongoDbContext.Logs.InsertOneAsync(log); // Cria log de criação de categoria.
        return Ok(newCategory);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCategoryName(string id, [FromBody] CategoryCreateDto newCategory)
    {
        var category = await _MongoDbContext.Category.Find(c => c.Id == id).FirstOrDefaultAsync();
        if (category == null) return NotFound("Categoria não encontrada.");

        var logOld = new Log { OldValue = $"{category.Name}" };

        category.Name = newCategory.Name; //realizando troca de nome
        if (category.Name == newCategory.Name) return BadRequest("O nome da categoria não pode ser igual ao anterior.");

        await _MongoDbContext.Category.ReplaceOneAsync(c => c.Id == id, category);


        var log = new Log
        {
            Date = DateTime.Now,
            UserName = User.Identity?.Name, //pega o usuário logado.
            ElementId = category.Id, //importante verificar se o insert de categoria cai no banco antes de puxar o id.
            ElementName = category.Name,
            Type = controllerName,
            OldValue = logOld.OldValue, //nome antigo
            Note = "Nome da categoria alterado."
        };

        await _MongoDbContext.Logs.InsertOneAsync(log); // Cria log de criação de categoria.
        return Ok("Categoria atualizada com sucesso.");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        await _MongoDbContext.Items.DeleteManyAsync(x => x.CategoryId == id);

        var category = await _MongoDbContext.Category.FindOneAndDeleteAsync(x => x.Id == id);
        if (category == null) NotFound("Categoria não encontrada.");
        var log = new Log
        {
            Date = DateTime.Now,
            UserName = User.Identity?.Name, //pega o usuário logado.
            ElementId = category?.Id, //importante verificar se o insert de categoria cai no banco antes de puxar o id.
            ElementName = category?.Name,
            Type = controllerName,
            OldValue = category?.Name, //nome antigo
            Note = "Categoria deletada."
        };

        await _MongoDbContext.Logs.InsertOneAsync(log); // Cria log de criação de categoria.
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(string id)
    {
        var category = await _MongoDbContext.Category.Find(c => c.Id == id).FirstOrDefaultAsync();
        if (category == null) return NotFound();
        var items = await _MongoDbContext.Items.Find(i => i.CategoryId == id).ToListAsync();
        category.Items = items;
        return Ok(category);
    }

    [HttpGet()]
    public async Task<ActionResult> GetAll()
    {
        var model = await _MongoDbContext.Category.Find(_ => true).ToListAsync();
        return Ok(model);
    }
}
using SteWebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace SteWebApi.Controllers;

[Authorize]
[Route("api/log")]
[ApiController]

public class LogController : ControllerBase
{
    private readonly MongoDbContext _MongoDbContext;

    public LogController(MongoDbContext context)
    {
        _MongoDbContext = context;
    }

    [HttpGet()]
    public async Task<ActionResult> GetAll()
    {
        var model = await _MongoDbContext.Logs.Find(_ => true).ToListAsync();
        return Ok(model);
    }

}
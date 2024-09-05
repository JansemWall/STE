using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SteWebApi.Model;
using SteWebApi.Services;

namespace SteWebApi.Controllers;

public class UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MongoDbContext _MongoDbContext;

        public UserController(MongoDbContext context)
        {
            _MongoDbContext = context;
        }
 
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate(AuthenticateDto model)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Name, model.Name);
            var userDb = await _MongoDbContext.Users.Find(filter).FirstOrDefaultAsync();
            if (userDb == null || userDb.Password != model.Password) return Unauthorized();
            JwtTokenGeneration jwtTokenGenerate = new JwtTokenGeneration();
            var jwt = jwtTokenGenerate.GenerateJwt(userDb);

            return Ok(jwt);
        }
        
        [HttpPost("Create")]
        public async Task<ActionResult> Create(User user)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = tokenHandler.ReadJwtToken(token).Claims;
            var perfilClaim = claims.FirstOrDefault(c => c.Type == "role");
            Console.WriteLine(perfilClaim.ToString());
            
            if ( perfilClaim == null || perfilClaim.Value != "Administrador")
            {
                return Unauthorized("Apenas administradores têm permissão para criar usuários.");
            }
            await _MongoDbContext.Users.InsertOneAsync(user);
            return Ok(user);
        }
        
        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> UpdateItemName(string id, [FromBody] User newUser)
        {
            var user = await _MongoDbContext.Users.Find(i => i.Id == id).FirstOrDefaultAsync();
            if (user == null) return NotFound();

            user.Name = newUser.Name;
            user.Password = newUser.Password;
            await _MongoDbContext.Users.ReplaceOneAsync(i => i.Id == id, user);

            return NoContent();
        }
        
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _MongoDbContext.Users.FindOneAndDeleteAsync(x => x.Id == id);
            if (user == null) return NotFound();

            return NoContent();
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetAll()
        {
            var model = await _MongoDbContext.Users.Find(_ => true).ToListAsync();
            return Ok(model);
        }
    }
}
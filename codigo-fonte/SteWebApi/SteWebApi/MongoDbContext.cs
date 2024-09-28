using MongoDB.Driver;
using SteWebApi.Model;

namespace SteWebApi;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;
    public IMongoCollection<User> Users => _database.GetCollection<User>("User");
    public IMongoCollection<Category> Category => _database.GetCollection<Category>("Category");
    public IMongoCollection<Item> Items => _database.GetCollection<Item>("Items");
    public IMongoCollection<LendingManager> ItemLending => _database.GetCollection<LendingManager>("ItemLending");
    
    
    public MongoDbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDB");
        var mongoClient = new MongoClient(connectionString);
        _database = mongoClient.GetDatabase("CrcEmpresta");
    }
}
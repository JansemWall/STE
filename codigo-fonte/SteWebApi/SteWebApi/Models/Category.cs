using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SteWebApi.Model;

public class Category
{
    public Category (string name=null)
    {
        this.Name = name;
    }
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [MinLength(5, ErrorMessage = "O nome da categoria deve ter pelo menos 5 caracteres.")]
    [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "O nome da categoria não pode conter caracteres especiais.")]
    [DefaultValue("Headset")]
    public string Name { get; set; }
    
    public List<Item> Items { get; set; } = new List<Item>();
}
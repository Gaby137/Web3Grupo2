using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Web3Grupo2.Models;

public class Ejemplo
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Name { get; set; }
}

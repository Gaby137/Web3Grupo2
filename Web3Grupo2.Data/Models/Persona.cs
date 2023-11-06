using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Web3Grupo2.Models;

public class Persona
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    public Direccion Casa { get; set; }
}
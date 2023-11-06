using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using Web3Grupo2.Models;

namespace Web3Grupo2.Repositories;
public interface IEjemploCollection
{
    void InsertEjemplo(Persona ejemplo);

    List<Persona> GetAllEjemplos();
    Persona GetEjemploById(string id);
    bool UpdateEjemplo(Persona ejemplo);
    bool DeleteEjemplo(Persona ejemplo);
}
public class EjemploCollection : IEjemploCollection
{
    internal MongoDBRepository _repository = new MongoDBRepository();
    private IMongoCollection<Persona> Collection;

    public EjemploCollection()
    {
        Collection = _repository.db.GetCollection<Persona>("Ejemplos");
    }
    public List<Persona> GetAllEjemplos()
    {
        return Collection.Find(_ => true).ToList();
    }

    /*
    public Persona GetEjemploById(string id)
    {

        ObjectId id1 = ObjectId.Parse(id);
        var filter = Builders<Persona>.Filter.Eq(e => e.Id, id1);
        return Collection.Find(filter).FirstOrDefault();
    } */

    public void InsertEjemplo(Persona ejemplo)
    {
        ejemplo.Casa = new Direccion { 
            Calle= ejemplo.Casa.Calle,
            Altura= ejemplo.Casa.Altura
        };
        Collection.InsertOneAsync(ejemplo);
    }
    public bool UpdateEjemplo(Persona ejemplo)
    {
        var filter = Builders<Persona>.Filter.Eq("_id", ejemplo.Id);
        var updateRes = Collection.ReplaceOne(filter, ejemplo);
        return updateRes.ModifiedCount == 1;
    }

    public bool DeleteEjemplo(Persona ejemplo)
    {
        var filter = Builders<Persona>.Filter.Eq("_id", ejemplo.Id);
        var deleteRes = Collection.DeleteOne(filter);
        return deleteRes.DeletedCount == 1;
    }
}

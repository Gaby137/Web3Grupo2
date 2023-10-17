using MongoDB.Driver;
using Web3Grupo2.Models;

namespace Web3Grupo2.Repositories;
public interface IEjemploCollection
{
    void InsertEjemplo(Ejemplo ejemplo);

    List<Ejemplo> GetAllEjemplos();
    Ejemplo GetEjemploById(string id);
}
public class EjemploCollection : IEjemploCollection
{
    internal MongoDBRepository _repository = new MongoDBRepository();
    private IMongoCollection<Ejemplo> Collection;

    public EjemploCollection()
    {
        Collection = _repository.db.GetCollection<Ejemplo>("Ejemplos");
    }
    public List<Ejemplo> GetAllEjemplos()
    {
        throw new NotImplementedException();
    }

    public Ejemplo GetEjemploById(string id)
    {
        throw new NotImplementedException();
    }

    public void InsertEjemplo(Ejemplo ejemplo)
    {
        Collection.InsertOneAsync(ejemplo);
    }
}

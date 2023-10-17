using MongoDB.Bson;
using MongoDB.Driver;

namespace Web3Grupo2.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");

            db = client.GetDatabase("Web3"); 
        }
    }

}

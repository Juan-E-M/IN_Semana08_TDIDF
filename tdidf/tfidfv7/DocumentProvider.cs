using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace tfidfv7.articles.parser
{
    public class DocumentProvider
    {
        private readonly IMongoClient _cliente;
        private readonly IMongoDatabase _db;
        public IMongoCollection<Document> Coleccion { get; }

        public DocumentProvider(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            _cliente = new MongoClient(connectionString);
            _db = _cliente.GetDatabase("Documents");
            Coleccion = _db.GetCollection<Document>("Documents");
        }

        public List<Document> GetAll()
        {
            return Coleccion.Find(_ => true).ToList();
        }
    }
}
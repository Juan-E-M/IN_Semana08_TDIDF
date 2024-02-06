using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace tfidfv7.articles.parser
{
    public class TokenProvider
    {
        private MongoClient Cliente { get; set; }
        private IMongoDatabase Db { get; set; }
        public IMongoCollection<Token> Coleccion
        {
            get { return Db.GetCollection<Token>("Tokens"); }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public TokenProvider(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            var client = new MongoClient(connectionString);
            Db = client.GetDatabase("Documents");
        }

        public void Insert(Token token)
        {
            Coleccion.InsertOne(token);
        }

        public List<Token> GetAll()
        {
            return Coleccion.Find(_ => true).ToList();
        }
    }
}

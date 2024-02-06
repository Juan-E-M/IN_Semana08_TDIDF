using MongoDB.Bson.Serialization.Attributes;

namespace tfidfv7.articles.parser
{
    /// <summary>
    /// Represents a token in a document
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Document in which a token appears
        /// </summary>
        [BsonRequired]
        public string Document { get; set; }

        /// <summary>
        /// Token of a document
        /// </summary>
        [BsonElement("Token")]
        public string Word { get; set; }

        /// <summary>
        /// Number of times the token appears in the document
        /// </summary>
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonRequired]
        public int Count { get; set; }

        /// <summary>
        /// Number of times the most seen token of the document appears
        /// </summary>
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonRequired]
        public int Max { get; set; }

        /// <summary>
        /// Normalized frequency of the token in the document (Count / Max)
        /// </summary>
        [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
        [BsonRequired]
        public double TF { get; set; }

        /// <summary>
        /// Total number of documents in the collection
        /// </summary>
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonRequired]
        public int DN { get; set; }

        /// <summary>
        /// Number of documents where the token is
        /// </summary>
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonRequired]
        public int CN { get; set; }

        /// <summary>
        /// IDF [Log(DN/(1+CN))]
        /// </summary>
        [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
        [BsonRequired]
        public double IDF { get; set; }

        /// <summary>
        /// TF-IDF value of the token in the document [TF*IDF]
        /// </summary>
        [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
        [BsonRequired]
        public double TFIDF { get; set; }
    }
}

using Microsoft.Extensions.Configuration;

namespace tfidfv7.articles.parser
{
    public class Parser
    {
        private readonly IConfiguration _configuration;

        // Constructor que recibe IConfiguration
        public Parser(IConfiguration configuration)
        {
            _configuration = configuration;
            this.Initialize();
        }

        public List<Document> Documents { get; set; }
        public List<Token> Tokens { get; set; }

        private void Initialize()
        {
            // Debes pasar la configuración a DocumentProvider
            DocumentProvider documentProvider = new DocumentProvider(_configuration);
            this.Documents = documentProvider.GetAll();
            Console.WriteLine(this.Documents);
        }


        internal void Execute()
        {
            List<Token> tokenList = new List<Token>();

            // Inserta los tokens de los documentos y cuenta.
            foreach (Document doc in this.Documents)
            {
                foreach (Section secc in doc.Sections)
                {
                    List<string> tokens = Generics.ExtractTokens(secc.Text);

                    foreach (string word in tokens)
                    {
                        Console.WriteLine(word);
                        if (tokenList.Any(x => x.Document == doc.Title && x.Word == word))
                        {
                            tokenList.First(x => x.Document == doc.Title && x.Word == word).Count++;
                        }
                        else
                        {
                            tokenList.Add(new Token()
                            {
                                Document = doc.Title,
                                Word = word,
                                Count = 1
                            });
                        }
                    }
                }
            }

            // Guarda las otras propiedades.
            foreach (Token item in tokenList)
            {
                if (item.Max == 0)
                {
                    item.Max = tokenList.Where(x => x.Document == item.Document).Max(x => x.Count);
                    item.TF = Convert.ToDouble(item.Count) / Convert.ToDouble(item.Max);
                }
                item.DN = tokenList.GroupBy(x => x.Document).Count();
                item.CN = tokenList.Count(x => x.Word == item.Word);
                item.IDF = Convert.ToDouble(Math.Log10(item.DN /item.CN));
                item.TFIDF = item.TF * item.IDF;
            }

            // Guarda en la base de datos.
            TokenProvider tokenProvider = new TokenProvider(_configuration);
            Console.WriteLine(tokenList);
            tokenList.ForEach(item => tokenProvider.Insert(item));
        }
    }

}

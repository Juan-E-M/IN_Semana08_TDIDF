using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using tfidfv7.articles.parser; // Asegúrate de usar el namespace correcto para tu proyecto.

class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        IConfiguration configuration = builder.Build();
        Console.WriteLine("comenzando...");

        Parser parser = new Parser(configuration);
        parser.Execute();
        Console.WriteLine("terminado");
    }
}

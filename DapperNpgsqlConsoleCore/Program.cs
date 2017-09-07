using System;
using Microsoft.Extensions.Configuration;

namespace DapperNpgsqlConsoleCore
{
    class Program
    {
        static int Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            
            // Keeping things simple and looking for connection string in environment variable
            // "Server=<db server>;Port=5432;User Id=<db user id>;Password=<db pass>;Database=<db name>;"
            var connectionString = config.GetSection("DAPPER_NPGSQL_CONN_STRING").Value;
            
            if (string.IsNullOrEmpty(connectionString)) 
            {
                Console.WriteLine("Specify database connection string in DAPPER_NPGSQL_CONN_STRING environment variable.");
                return 1;
            }

            using (var t = new DataRetriever(connectionString))
            {
                Console.WriteLine("Beers{0}=====", Environment.NewLine);

                var beers = t.GetBeers();

                foreach (var beer in beers)
                {
                    Console.WriteLine("{0} - {1}", beer.Name, beer.Abv);
                }

                Console.WriteLine("{0}Styles{0}======", Environment.NewLine);

                var styles = t.GetStyles();

                foreach (var style in styles)
                {
                    Console.WriteLine("{0} - {1}", style.Name, style.Description);
                }
                
                return 0;
            }
        }
    }
}

using System;
using Microsoft.Extensions.Configuration;

namespace DapperNpgsqlConsoleCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO - System.Configuration not present in .NET Core so this needs to be redone
            string connectionString = "Server=DBSERVER;Port=5432;User Id=DBUSER;Password=DBPASS;Database=DBNAME;";

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
            }
        }
    }
}

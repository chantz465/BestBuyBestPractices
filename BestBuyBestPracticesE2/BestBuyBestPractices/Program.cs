using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperProductRepository(conn);

            repo.CreateProduct("Bacon Stove", 19.99, 34);


            var product = repo.GetAllProduct();
           

            foreach (var item in product)
            {
                Console.WriteLine(item.ProductID);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.CategoryID);
                Console.WriteLine(item.OnSale);
                Console.WriteLine(item.StockLevel);
                Console.WriteLine();
            }


        }
    }
}

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
            var departmentRepo = new DapperDepartmentRepository(conn);

            departmentRepo.InsertDepartment("test");
            var departments = departmentRepo.GetAllDepartments();
            departmentRepo.DeleteDepartment(8,10);
           

            foreach (var item in departments)
            {
                Console.WriteLine(item.DepartmentID);
                Console.WriteLine(item.Name);
                Console.WriteLine();
            }


        }
    }
}

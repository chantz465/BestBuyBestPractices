using Dapper;
using IntroSQL;
using System.Collections.Generic;
using System.Data;
using System;


public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;
    //Constructor
    public DapperProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Product> GetAllProduct()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    public void CreateProduct(string NewName, double newPrice, int categoryID)
    {
        _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
            new { name = NewName,price = newPrice, categoryID = categoryID});
    }

    public void UpdateDepartment(string name, double price, int id)
    {
        _connection.Execute("UPDATE departments Set Name = @name, price  = @price WHERE ProductID = @id;",
            new { name = name, price = price, id = id });

    }

    public void DeleteDepartment(int productID)
    {
        _connection.Execute("DELETE FROM reviews Where ProductID = @productID});",
            new {productID = productID});
    }

    public IEnumerable<Product> GetAllProducts()
    {
        throw new System.NotImplementedException();
    }
}
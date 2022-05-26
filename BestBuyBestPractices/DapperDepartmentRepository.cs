using Dapper;
using IntroSQL;
using System.Collections.Generic;
using System.Data;

public class DapperDepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;
    //Constructor
    public DapperDepartmentRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM Departments;");
    }

    public void InsertDepartment(string name)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@name);", new { name = name });
    }

    public void UpdateDepartment(int departmentID, string updatedName)
    {
        _connection.Execute("UPDATE departments Set Name = @updatedName WHERE Deparment = @departmentID;",
            new { deparmentID = departmentID, updatedName = updatedName});

    }

    public void DeleteDepartment(int start, int end)
    {
        _connection.Execute("DELETE FROM departments WHERE DepartmentID BETWEEN @start and @end;", new { start = start, end = end });
    }
}
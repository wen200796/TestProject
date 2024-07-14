using Dapper;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using System.Data.SqlClient;
using Testcontainers.MsSql;

namespace Tests
{
    public class Tests
    {
        IContainer _dbContainer;
       [SetUp]
        public void Setup()
        {

            
    }

        [Test]
        public async Task  Test1()
        {
            var container = await TestContainersContainer.CreateAsync();

            await using var connection = new SqlConnection(container.ConnectionString);

            string sql = @"CREATE TABLE Persons (
    PersonID int,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255)
);";



            await connection.ExecuteAsync(sql);

            string sql2 = @"INSERT INTO Persons (PersonID, LastName, FirstName, Address, City)
VALUES 
(1, 'Doe', 'John', '123 Main St', 'Anytown'),
(2, 'Smith', 'Jane', '456 Elm St', 'Othertown');";

            int resutl = await connection.ExecuteAsync(sql2);

            Assert.That(resutl , Is.EqualTo(2));
        }

        [Test]
        public async Task Test2()
        {
            var container = await TestContainersContainer.CreateAsync();

            await using var connection = new SqlConnection(container.ConnectionString);

            string sql = @"CREATE TABLE Persons (
    PersonID int,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255)
);";



            await connection.ExecuteAsync(sql);

            string sql2 = @"INSERT INTO Persons (PersonID, LastName, FirstName, Address, City)
VALUES 
(1, 'Doe', 'John', '123 Main St', 'Anytown'),
(2, 'Smith', 'Jane', '456 Elm St', 'Othertown');";

            int resutl = await connection.ExecuteAsync(sql2);

            Assert.That(resutl, Is.EqualTo(2));
        }


    }
}
# DapperAddons

Dapper is an object–relational mapping product for the Microsoft .NET platform: it provides a framework for mapping an object-oriented domain model to a traditional relational database. Its purpose is to relieve the developer from a significant portion of relational data persistence-related programming tasks

Since the Dipper package is an open source and freely available, why do I need to create this package? Well, you're right. The main purpose behind DapperAddons is to provide convincing, concise methods so that developers become more productive.

## What is Dapper Addons Package?

Dapper Addons is a set of helpful methods that make a developer's life easier when working with a database. Dapper Addons include methods such as GetOneAsync, GetOneByStoreProcedureAsync, GetAllAsync, GetAllByStoreProcedureAsync, InserOneAsync and InsertOneByStoreProcedureAsync, UpdateOneAsync and UpdateOneByStoreProcedureAsync, DeleteAsync and DeleteByStoreProcedureAsync to create, update, or delete records without having to worry about opening and closing sql connections, as well as object casting.

### How to use Dapper Addons:

Currently Dapper Addons contains two types of methods.

- 1: Methods to perform CRUD operations via query
- 2: Methods to perform CRUD operations via store procedure name

#### Let's start with DbHelpers

- 1 => : Install DapperAddons Package
- 2 => : Register AddDapperAddons in services container. To register this package, simply add this code in Program.cs file (Previously this file known as startup.cs)
  builder.Services.AddDapperAddons();
- 3 => : Inject IDbhelpers into the constructor of the class in which you want to perform the database operation. To inject IDbhelpers, simply add this code to your constructor

```C#
public class YourClass
{
    private readonly IDbHelpers _dbHelpers;
    public YourClass(IDbHelpers dbHelpers)
    {
        _dbHelpers = dbHelpers;
    }
}
```

- Congratulations => : You are good to go. Now you can perform any database operation such as inserting, updating, deleting and retrieving data via query or store procedure.

##### Note: I am writing a few examples to use this package, however more examples will be added soon. Any questions or suggestions are greatly appreciated.

##### Quick Reminder:

Return type and Input parameters can be simply system or user define data type such as string, class, object or dynamic.

While using this package, you have the option of using Raw SQL Query or name of SQL Store Procedure to get the job done. If you wish to use the stored procedure, call only those methods whose name contains the stored procedure keyword such as GetOneByStoreProcedure, GetAllByStoreProcedure.

##### Use of GetAllAsync or GetAllByStoreProcedureAsync:

- Note: You must already inject IDbHelpers to your constructor

```C#
public class YourClass
{
    private readonly IDbHelpers _dbHelpers;
    public YourClass(IDbHelpers dbHelpers)
    {
        _dbHelpers = dbHelpers;
    }
}
```

##### Now, lets call GetAllAsync method

```C#
    string yourQuery = "select * from countries";
    // If you connection string name is DefaultConnection, then there is no need to pass connection string name, else you have to specify the connection string name.
    var result = await _dbHelpers.GetAllAsync(yourQuery);

    // To pass connection string, you must already defined connection string in appsettings.json before to use its name here
    // It will return list of countries Database helper method for retrieving one record from database
    var resultWithDifferentConnectionString = await _dbHelpers.GetAllAsync(yourQuery, "ConnectionStringName");
```

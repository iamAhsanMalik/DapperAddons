# DapperAddons

Dapper is an object–relational mapping product for the Microsoft .NET platform: it provides a framework for mapping an object-oriented domain model to a traditional relational database. Its purpose is to relieve the developer from a significant portion of relational data persistence-related programming tasks

Since the Dipper package is an open source and freely available, why do I need to create this package? Well, you're right. The main purpose behind DapperAddons is to provide convincing, concise methods so that developers become more productive.

What is Dapper Addons Package?
Dapper Addons is a set of helpful methods that make a developer's life easier when working with a database. Dapper Addons include methods such as GetOneAsync, GetOneByStoreProcedureAsync, GetAllAsync, GetAllByStoreProcedureAsync, InserOneAsync and InsertOneByStoreProcedureAsync, UpdateOneAsync and UpdateOneByStoreProcedureAsync, DeleteAsync and DeleteByStoreProcedureAsync to create, update, or delete records without having to worry about opening and closing sql connections, as well as object casting.

# How to use Dapper Addons:

#### 1: Inject DbHelpers to the constructor.

#### 2: Call any method, specify your return type, specify input parameters and name of connection string.

#### Return type and Input parameters can be simply system or user define data type such as string, class, object or dynamic.

You have the option of using Raw SQL Query or SQL Store Procedure to get the job done. If you wish to use the stored procedure, call only those methods whose name contains the stored procedure.

#### Use of GetOneAsync or GetOneByStoreProcedureAsync:

Database helper method for retrieving one record from database

#### Use of GetAllAsync, GetAllByStoreProcedureAsync:

Database helper method to get the list of records

#### InserOneAsync and InsertOneByStoreProcedureAsync:

Database Helper method to insert / save a record in a database

#### UpdateOneAsync and UpdateOneByStoreProcedureAsync:

Database Helper method for updating a record in database

#### DeleteAsync and DeleteOneByStoreProcedureAsync:

Database Helper method for deleting records from database

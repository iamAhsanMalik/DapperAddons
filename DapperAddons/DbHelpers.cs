using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DapperAddons;
/// <summary>
/// Database helper methods to perform CRUD operations in a convenient way
/// </summary>
public class DbHelpers : IDbHelpers
{
    private readonly IConfiguration _configuration;

    public DbHelpers(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    #region Dapper Query Region
    // ------------------------- //
    // Dapper Query Executer
    // ------------------------ //

    #region Dapper Method to Get Result Set Via Query 
    /// <summary>
    /// Database helper method to get the list of records using sql query
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionID"></param>
    /// <returns></returns>
    public async Task<List<ReturnType>> GetAllAsync<ReturnType, InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default(InputParemeters), string connectionID = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionID)))
        {
            dbConnection.Open();
            List<ReturnType> resultSet = (await dbConnection.QueryAsync<ReturnType>(sqlQuery, inputParameters)).ToList();
            dbConnection.Close();
            return resultSet;
        }
    }
    #endregion

    #region Dapper Method to Get Single Result via Query
    /// <summary>
    /// Database helper method for retrieving one record from database using sql query
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionID"></param>
    /// <returns></returns>
    public async Task<ReturnType> GetOneAsync<ReturnType, InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default(InputParemeters), string connectionID = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionID)))
        {
            dbConnection.Open();
            ReturnType result = await dbConnection.QueryFirstOrDefaultAsync<ReturnType>(sqlQuery, inputParameters);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Insert Data via Query
    /// <summary>
    /// Database Helper method to insert / save a record in a database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionID"></param>
    /// <returns></returns>
    public async Task<int> InsertOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default(InputParemeters), string connectionID = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionID)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(sqlQuery, inputParameters);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Update Data via Query
    /// <summary>
    /// Database Helper method for updating a record in database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionID"></param>
    /// <returns></returns>
    public async Task<int> UpdateOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default(InputParemeters), string connectionID = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionID)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(sqlQuery, inputParameters);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Delete Data via Query
    /// <summary>
    /// Database Helper method for deleting records from database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionID"></param>
    /// <returns></returns>
    public async Task<int> DeleteAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default(InputParemeters), string connectionID = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionID)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(sqlQuery, inputParameters);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Store Procedure Region
    // ---------------------------------- //
    // Dapper Store Procedures Executers
    // ---------------------------------- //


    #region Dapper Method to Get Result Set via Store Procedure
    /// <summary>
    /// Database helper method to get the list of records using sql store procedure
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedure"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionID"></param>
    /// <returns></returns>
    public async Task<List<ReturnType>> GetAllByStoreProcedureAsync<ReturnType, InputParemeters>(string storeProcedure, InputParemeters? inputParameters = default(InputParemeters), string connectionID = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionID)))
        {
            dbConnection.Open();
            List<ReturnType> resultSet = (await dbConnection.QueryAsync<ReturnType>(storeProcedure, inputParameters, commandType: CommandType.StoredProcedure)).ToList();
            dbConnection.Close();
            return resultSet;
        };
    }
    #endregion

    #region Dapper Method to Get Single Result via Store Procedure
    /// <summary>
    /// Database helper method for retrieving one record from database using sql store procedure
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedure"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionID"></param>
    /// <returns></returns>
    public async Task<ReturnType> GetOneByStoreProcedureAsync<ReturnType, InputParemeters>(string storeProcedure, InputParemeters? inputParameters = default(InputParemeters), string connectionID = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionID)))
        {
            dbConnection.Open();
            ReturnType result = await dbConnection.QueryFirstOrDefaultAsync<ReturnType>(storeProcedure, inputParameters, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Insert Data via Store Procedure
    /// <summary>
    /// Database Helper method to insert / save a record in a database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedure"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionID"></param>
    /// <returns></returns>
    public async Task<int> InsertOneByStoreProcedureAsync<InputParemeters>(string storeProcedure, InputParemeters? inputParameters = default(InputParemeters), string connectionID = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionID)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(storeProcedure, inputParameters, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Update Data via Store Procedure
    /// <summary>
    /// Database Helper method for updating a record in database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedure"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionID"></param>
    /// <returns></returns>
    public async Task<int> UpdateOneByStoreProcedureAsync<InputParemeters>(string storeProcedure, InputParemeters? inputParameters = default(InputParemeters), string connectionID = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionID)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(storeProcedure, inputParameters, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Delete Data via Store Procedure
    /// <summary>
    /// Database Helper method for deleting records from database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedure"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionID"></param>
    /// <returns></returns>
    public async Task<int> DeleteByStoreProcedureAsync<InputParemeters>(string storeProcedure, InputParemeters? inputParameters = default(InputParemeters), string connectionID = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionID)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(storeProcedure, inputParameters, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion
    #endregion

    #endregion
}

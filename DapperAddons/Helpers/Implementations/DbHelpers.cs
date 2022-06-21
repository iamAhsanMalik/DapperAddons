using Dapper;
using DapperAddons.Helpers.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DapperAddons.Helpers.Implementations;
/// <summary>
/// Database helper methods to perform CRUD operations in a convenient way
/// </summary>
public class DbHelpers : IDbHelpers
{
    private readonly IConfiguration _configuration;
    /// <summary>
    /// Dbhelpers constructor used to inject configuration service for SQL connections.
    /// </summary>
    /// <param name="configuration"></param>
    public DbHelpers(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    #region Dapper Query Region
    // ------------------------- //
    // Dapper Query Executer
    // ------------------------ //

    #region Dapper Method to Get Records Via Query 
    /// <summary>
    /// Get list of records using sql query
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="connectionStringName"></param>
    /// <returns>List of objects you specified as a return type</returns>
    public async Task<List<ReturnType>> GetAllAsync<ReturnType>(string sqlQuery, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            List<ReturnType> resultSet = (await dbConnection.QueryAsync<ReturnType>(sqlQuery)).ToList();
            dbConnection.Close();
            return resultSet;
        }
    }
    #endregion

    #region Dapper Method to Get Records Via Query 
    /// <summary>
    /// Get list of records using sql query
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns>List of objects you specified as a return type</returns>
    public async Task<List<ReturnType>> GetAllAsync<ReturnType, InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            List<ReturnType> resultSet = (await dbConnection.QueryAsync<ReturnType>(sqlQuery, inputParameters)).ToList();
            dbConnection.Close();
            return resultSet;
        }
    }
    #endregion

    #region Dapper Method to Get Single Record via Query
    /// <summary>
    /// Retrieve single record from database using sql query
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<ReturnType> GetOneAsync<ReturnType>(string sqlQuery, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            ReturnType result = await dbConnection.QueryFirstOrDefaultAsync<ReturnType>(sqlQuery);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Get Single Record via Query
    /// <summary>
    /// Retrieve single record from database using sql query
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<ReturnType> GetOneAsync<ReturnType, InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            ReturnType result = await dbConnection.QueryFirstOrDefaultAsync<ReturnType>(sqlQuery, inputParameters);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Insert Single Record via Query
    /// <summary>
    /// Save single record in database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> InsertOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(sqlQuery, inputParameters);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Bulk Insert Records via Query
    /// <summary>
    /// Save multiple records in database using sql query 
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> BulkInsertAsync<InputParemeters>(string sqlQuery, IEnumerable<InputParemeters>? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(sqlQuery, inputParameters);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Update Single Record via Query
    /// <summary>
    /// Update single record in database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> UpdateOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(sqlQuery, inputParameters);
            dbConnection.Close();
            return result;
        };
    }
    #endregion
    #region Dapper Method to Bulk Update Records via Query
    /// <summary>
    /// Update multiple records in database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> BulkUpdateAsync<InputParemeters>(string sqlQuery, IEnumerable<InputParemeters>? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(sqlQuery, inputParameters);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Delete Single Record via Query
    /// <summary>
    /// Delete single record from database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> DeleteOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(sqlQuery, inputParameters);
            dbConnection.Close();
            return result;
        };
    }
    #endregion
    #region Dapper Method to Bulk Delete Records via Query
    /// <summary>
    /// Delete multiple records from database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> BulkDeleteAsync<InputParemeters>(string sqlQuery, IEnumerable<InputParemeters>? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
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

    #region Dapper Method to Get Records via Store Procedure
    /// <summary>
    /// Get list of records using sql store procedure
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="connectionStringName"></param>
    /// <returns>List of objects you specified as a return type</returns>
    public async Task<List<ReturnType>> GetAllByStoreProcedureAsync<ReturnType>(string storeProcedureName, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            List<ReturnType> resultSet = (await dbConnection.QueryAsync<ReturnType>(storeProcedureName, commandType: CommandType.StoredProcedure)).ToList();
            dbConnection.Close();
            return resultSet;
        };
    }
    #endregion

    #region Dapper Method to Get Records via Store Procedure
    /// <summary>
    /// Get list of records using sql store procedure
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns>List of objects you specified as a return type</returns>
    public async Task<List<ReturnType>> GetAllByStoreProcedureAsync<ReturnType, InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            List<ReturnType> resultSet = (await dbConnection.QueryAsync<ReturnType>(storeProcedureName, inputParameters, commandType: CommandType.StoredProcedure)).ToList();
            dbConnection.Close();
            return resultSet;
        };
    }
    #endregion


    #region Dapper Method to Get Single Record via Store Procedure
    /// <summary>
    /// Retrievee single record from database using sql store procedure
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<ReturnType> GetOneByStoreProcedureAsync<ReturnType>(string storeProcedureName, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            ReturnType result = await dbConnection.QueryFirstOrDefaultAsync<ReturnType>(storeProcedureName, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Get Single Record via Store Procedure
    /// <summary>
    /// Retrieve single record from database using sql store procedure
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<ReturnType> GetOneByStoreProcedureAsync<ReturnType, InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            ReturnType result = await dbConnection.QueryFirstOrDefaultAsync<ReturnType>(storeProcedureName, inputParameters, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Insert Record via Store Procedure
    /// <summary>
    /// Save single record in database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> InsertOneByStoreProcedureAsync<InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(storeProcedureName, inputParameters, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Bulk Insert Records via Store Procedure
    /// <summary>
    /// Save multiple records in database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> BulkInsertByStoreProcedureAsync<InputParemeters>(string storeProcedureName, IEnumerable<InputParemeters>? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(storeProcedureName, inputParameters, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion
    #region Dapper Method to Update Record via Store Procedure
    /// <summary>
    /// Update single record in database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> UpdateOneByStoreProcedureAsync<InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(storeProcedureName, inputParameters, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Bulk Update Records via Store Procedure
    /// <summary>
    /// Update multiple records in database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> BulkUpdateByStoreProcedureAsync<InputParemeters>(string storeProcedureName, IEnumerable<InputParemeters>? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(storeProcedureName, inputParameters, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion

    #region Dapper Method to Delete Record via Store Procedure
    /// <summary>
    /// Delete single record from database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> DeleteOneByStoreProcedureAsync<InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(storeProcedureName, inputParameters, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion
    #region Dapper Method to Bulk Delete Records via Store Procedure
    /// <summary>
    /// Delete multiple records from database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    public async Task<int> BulkDeleteByStoreProcedureAsync<InputParemeters>(string storeProcedureName, IEnumerable<InputParemeters>? inputParameters = default, string connectionStringName = "DefaultConnection")
    {
        using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName)))
        {
            dbConnection.Open();
            int result = await dbConnection.ExecuteAsync(storeProcedureName, inputParameters, commandType: CommandType.StoredProcedure);
            dbConnection.Close();
            return result;
        };
    }
    #endregion
    #endregion
    #endregion
}

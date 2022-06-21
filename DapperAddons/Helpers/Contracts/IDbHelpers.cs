namespace DapperAddons.Helpers.Contracts;
/// <summary>
/// Database helper methods to perform CRUD operations in a convenient way
/// </summary>
public interface IDbHelpers
{
    /// <summary>
    /// Delete multiple records from database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> BulkDeleteAsync<InputParemeters>(string sqlQuery, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Delete multiple records from database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> BulkDeleteByStoreProcedureAsync<InputParemeters>(string storeProcedureName, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Save multiple records in database using sql query 
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> BulkInsertAsync<InputParemeters>(string sqlQuery, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Save multiple records in database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> BulkInsertByStoreProcedureAsync<InputParemeters>(string storeProcedureName, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Update multiple records in database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> BulkUpdateAsync<InputParemeters>(string sqlQuery, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Update multiple records in database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> BulkUpdateByStoreProcedureAsync<InputParemeters>(string storeProcedureName, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Delete single record from database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> DeleteOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Delete single record from database using sql store procedure 
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> DeleteOneByStoreProcedureAsync<InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Get list of records using sql query
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<List<ReturnType>> GetAllAsync<ReturnType, InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Get list of records using sql query
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<List<ReturnType>> GetAllAsync<ReturnType>(string sqlQuery, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Get list of records using sql store procedure
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<List<ReturnType>> GetAllByStoreProcedureAsync<ReturnType, InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Get list of records using sql store procedure
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<List<ReturnType>> GetAllByStoreProcedureAsync<ReturnType>(string storeProcedureName, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Retrieve single record from database using sql query
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<ReturnType> GetOneAsync<ReturnType, InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Retrieve single record from database using sql query
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<ReturnType> GetOneAsync<ReturnType>(string sqlQuery, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Retrieve single record from database using sql store procedure
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<ReturnType> GetOneByStoreProcedureAsync<ReturnType, InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Retrieve single record from database using sql store procedure
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<ReturnType> GetOneByStoreProcedureAsync<ReturnType>(string storeProcedureName, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Save single record in database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> InsertOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Save single record in database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> InsertOneByStoreProcedureAsync<InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Update single record in database using sql query
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="sqlQuery"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> UpdateOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection");

    /// <summary>
    /// Update single record in database using sql store procedure
    /// </summary>
    /// <typeparam name="InputParemeters"></typeparam>
    /// <param name="storeProcedureName"></param>
    /// <param name="inputParameters"></param>
    /// <param name="connectionStringName"></param>
    /// <returns></returns>
    Task<int> UpdateOneByStoreProcedureAsync<InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "DefaultConnection");
}

namespace DapperAddons;

public interface IDbHelpers
{
    Task<int> DeleteAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionID = "DefaultConnection");
    Task<int> DeleteByStoreProcedureAsync<InputParemeters>(string storeProcedure, InputParemeters? inputParameters = default, string connectionID = "DefaultConnection");
    Task<List<ReturnType>> GetAllAsync<ReturnType, InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionID = "DefaultConnection");
    Task<List<ReturnType>> GetAllByStoreProcedureAsync<ReturnType, InputParemeters>(string storeProcedure, InputParemeters? inputParameters = default, string connectionID = "DefaultConnection");
    Task<ReturnType> GetOneAsync<ReturnType, InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionID = "DefaultConnection");
    Task<ReturnType> GetOneByStoreProcedureAsync<ReturnType, InputParemeters>(string storeProcedure, InputParemeters? inputParameters = default, string connectionID = "DefaultConnection");
    Task<int> InsertOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionID = "DefaultConnection");
    Task<int> InsertOneByStoreProcedureAsync<InputParemeters>(string storeProcedure, InputParemeters? inputParameters = default, string connectionID = "DefaultConnection");
    Task<int> UpdateOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionID = "DefaultConnection");
    Task<int> UpdateOneByStoreProcedureAsync<InputParemeters>(string storeProcedure, InputParemeters? inputParameters = default, string connectionID = "DefaultConnection");
}
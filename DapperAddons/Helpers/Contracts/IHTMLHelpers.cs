using Microsoft.AspNetCore.Mvc.Rendering;

namespace DapperAddons.Helpers.Contracts;

public interface IHTMLHelpers
{
    Task<List<SelectListItem>> PopulateDropDownAsync(string sqlQuery, string Text, string Value, string selectedValue = "", string disabledValue = "", string optionalLabel = "", string connectionStringName = "DefaultConnection");
}
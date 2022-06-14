using DapperAddons.DTOs;
using DapperAddons.Helpers.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAddons.Helpers.Implementations;
/// <summary>
/// HTML Helpers to easily render data in the HTML view page
/// </summary>
public class HTMLHelpers : IHTMLHelpers
{
    private readonly IDbHelpers _dbHelpers;
    /// <summary>
    /// HTMLHelpers constructor used to inject IDbHelpers to use database methods
    /// </summary>
    /// <param name="dbHelpers"></param>
    public HTMLHelpers(IDbHelpers dbHelpers)
    {
        _dbHelpers = dbHelpers;
    }
    /// <summary>
    /// The HTML helper method used to retrieve data in the form of SelectListItem, so you can pass this list to html and it will be rendered as a select list.
    /// </summary>
    /// <param name="sqlQuery"></param>
    /// <param name="Text"></param>
    /// <param name="Value"></param>
    /// <param name="selectedValue"></param>
    /// <param name="disabledValue"></param>
    /// <param name="optionalLabel"></param>
    /// <param name="connectionStringName"></param>
    /// <returns>List of SelectListItem objects</returns>
    public async Task<List<SelectListItem>> PopulateDropDownAsync(string sqlQuery, string Text, string Value, string selectedValue = "", string disabledValue = "", string optionalLabel = "", string connectionStringName = "DefaultConnection")
    {
        List<DropDownDTO> dropDownData = await _dbHelpers.GetAllAsync<DropDownDTO>(sqlQuery);

        SelectListItem mylist = new SelectListItem();
        List<SelectListItem> dropdownList = new List<SelectListItem>();

        mylist.Value = String.Empty;
        mylist.Text = optionalLabel;
        mylist.Selected = selectedValue == "" ? true : false;

        dropdownList.Add(mylist);

        if (dropDownData != null && dropDownData.Any() == true)
        {
            dropdownList.AddRange(dropDownData.Select(item => new SelectListItem {
                Text = item.Text,
                Value = item.Value,
                Selected = selectedValue.ToLower() == item.Value?.ToLower() ? true : false,
                Disabled = disabledValue.ToLower() == item.Value?.ToLower() ? true : false
            }).ToList());
        }
        return dropdownList;
    }
}

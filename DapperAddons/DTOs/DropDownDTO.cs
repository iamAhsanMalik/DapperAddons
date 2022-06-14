using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAddons.DTOs;
/// <summary>
/// A class representing the HTML drop-down options. 
/// </summary>
public class DropDownDTO
{
    /// <summary>
    /// Drop-down text which we place between the opening and closing options tags. Example: <option> Text </option>
    /// </summary>
    public string? Text { get; set; }
    /// <summary>
    /// Drop-down value which we write in opening option tags. Example: <option value=" Value "> Text </option>
    /// </summary>
    public string? Value { get; set; }
    /// <summary>
    /// This represents the selected value / text of the drop-down list.
    /// </summary>
    public bool Selected { get; set; }
    /// <summary>
    /// This represents the disabled value / text of the drop-down list.
    /// </summary>
    public string? Disabled { get; set; }
}

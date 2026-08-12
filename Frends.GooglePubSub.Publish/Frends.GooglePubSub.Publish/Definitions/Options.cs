using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.GooglePubSub.Publish.Definitions;

/// <summary>
/// Options for the Publish task.
/// </summary>
public class Options
{
    /// <summary>
    /// Throw an exception on failure.
    /// </summary>
    /// <example>true</example>
    [DefaultValue(true)]
    public bool ThrowErrorOnFailure { get; set; } = true;

    /// <summary>
    /// Custom error message to use when throwing an exception.
    /// </summary>
    /// <example>Publishing failed</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("")]
    public string ErrorMessageOnFailure { get; set; } = string.Empty;
}

using System.Globalization;
using System.Windows.Data;

namespace PL;

/// <summary>
/// Converts an ID value to content, returning "Add" if the value is -1, otherwise "Update".
/// </summary>
class ConvertIdToContent : IValueConverter
{
    /// <summary>
    /// Converts an ID value to content.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">The type to convert to.</param>
    /// <param name="parameter">An optional parameter.</param>
    /// <param name="culture">The culture to use in the conversion.</param>
    /// <returns>"Add" if the value is -1, otherwise "Update".</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == -1 ? "Add" : "Update";
    }

    /// <summary>
    /// Converts a value back. This operation is not supported and will throw <see cref="NotImplementedException"/>.
    /// </summary>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Converts an ID value to a boolean indicating enable state, returning "True" if the value is -1, otherwise "False".
/// </summary>
class ConvertIdToBoolEnable : IValueConverter
{
    /// <summary>
    /// Converts an ID value to a boolean indicating enable state.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">The type to convert to.</param>
    /// <param name="parameter">An optional parameter.</param>
    /// <param name="culture">The culture to use in the conversion.</param>
    /// <returns>"True" if the value is -1, otherwise "False".</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == -1 ? "True" : "False";
    }

    /// <summary>
    /// Converts a value back. This operation is not supported and will throw <see cref="NotImplementedException"/>.
    /// </summary>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}



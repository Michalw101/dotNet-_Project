namespace BO
{
    /// <summary>
    /// Provides utility methods for the business logic layer.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Converts an object's properties to a string representation.
        /// </summary>
        /// <param name="p">The object whose properties to convert.</param>
        /// <returns>A string representation of the object's properties.</returns>
        public static string ToStringProperty(this object p)
        {
            var prop = p.GetType().GetProperties();
            string str = "";
            foreach (var property in prop)
            {
                str += property.Name + " : " + property.GetValue(p) + "\n";
            }
            return str;
        }
    }
}

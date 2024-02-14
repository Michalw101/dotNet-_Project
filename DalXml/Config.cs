namespace Dal
{
    /// <summary>
    /// Provides configuration settings for the data access layer.
    /// </summary>
    internal static class Config
    {
        private static string s_data_config_xml = "data-config";

        /// <summary>
        /// Gets the ID for the next task.
        /// </summary>
        internal static int NextTaskId { get => XMLTools.GetAndIncreaseNextId(s_data_config_xml, "NextTaskId"); }

        /// <summary>
        /// Gets the ID for the next dependency.
        /// </summary>
        internal static int NextDependencyId { get => XMLTools.GetAndIncreaseNextId(s_data_config_xml, "NextDependencyId"); }
    }
}
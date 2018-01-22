using System.Configuration;

namespace ForumApp.Common.Global
{
    /// <summary>
    /// Defiens the globally constant values
    /// </summary>
    public class Constants
    {
        public static readonly string FrontendUrl = ConfigurationManager.AppSettings.Get("FrontendUrl");
    }
}

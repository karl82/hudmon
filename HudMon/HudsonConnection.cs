
namespace HudMon
{
    /// <summary>
    /// Stores URL and credentials for connection to Hudson server
    /// </summary>
    public class HudsonConnection
    {
        /// <summary>
        /// URL path to Hudson server
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}

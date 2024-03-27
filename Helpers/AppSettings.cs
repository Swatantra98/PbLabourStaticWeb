namespace PbLabourStatic.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; } = string.Empty;

        public string AesKey { get; set; } = string.Empty;

        public string AesIV { get; set; } = string.Empty;

        public string PageSize { get; set; } = string.Empty;

        public bool IsLoggedIn { get; set; }
    }
}

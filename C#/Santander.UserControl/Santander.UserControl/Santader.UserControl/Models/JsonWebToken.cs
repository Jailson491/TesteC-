namespace Santader.UserControl.Models
{
    public class JsonWebToken
    {
        public string? AccessToken { get; set; }
        public bool authenticated { get; set; }
        public long ExpiresIn { get; set; }
        public string? message { get; set; }

    }
}

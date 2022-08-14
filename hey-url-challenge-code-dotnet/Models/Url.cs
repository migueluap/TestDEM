using System;

namespace hey_url_challenge_code_dotnet.Models
{
    public class Url
    {
        public int Id { get; set; }
        public string ShortUrl { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Count { get; set; }
    }
}

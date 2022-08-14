using System;
using System.Collections.Generic;

namespace hey_url_challenge_code_dotnet.Models
{
    public class Url
    {
        public int Id { get; set; }
        public string ShortUrl { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public int Count { get; set; } = 0;
        public List<Click> Clicks { get; set; } = new List<Click>();    
    }
}

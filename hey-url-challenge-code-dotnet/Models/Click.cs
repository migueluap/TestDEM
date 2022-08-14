using System;

namespace hey_url_challenge_code_dotnet.Models
{
    public class Click
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string OS { get; set; }
        public string Browser { get; set; }

        public int IdUrl { get; set; }
    }
}

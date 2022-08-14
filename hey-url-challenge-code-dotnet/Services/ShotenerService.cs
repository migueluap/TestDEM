using System;
using System.Linq;

namespace hey_url_challenge_code_dotnet.Services
{
    public class ShortenerService
    {
        public string ShortCode { get; set; }
        //public ShortenerService GenerateShotCode()
        public string GenerateShortCode()
        {
            string urlsafe = string.Empty;


            Enumerable.Range(48, 75)
                .Where(i => i > 64 && i < 91)
                .OrderBy(o => new Random().Next())
                .ToList()
                .ForEach(i => urlsafe += Convert.ToChar(i));
            //ShortCode = urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6)).ToUpper();
            //return this;
            string shortCode1 = urlsafe.Substring(new Random().Next(0, urlsafe.Length -1), 4).ToUpper();
            return shortCode1;

            //Enumerable.Range(48, 75)
            //    .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
            //    .OrderBy(o => new Random().Next())
            //    .ToList()
            //    .ForEach(i => urlsafe += Convert.ToChar(i));
            ////ShortCode = urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6)).ToUpper();
            ////return this;
            //string shortCode = urlsafe.Substring(new Random().Next(0, urlsafe.Length), 4).ToUpper();
            //return shortCode;
        }

    }
}

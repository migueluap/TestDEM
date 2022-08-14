using System;
using System.Collections.Generic;
using System.Linq;
using hey_url_challenge_code_dotnet.Common;
using hey_url_challenge_code_dotnet.Models;
using hey_url_challenge_code_dotnet.Services;
using hey_url_challenge_code_dotnet.ViewModels;
using HeyUrlChallengeCodeDotnet.Data;
using HeyUrlChallengeCodeDotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shyjus.BrowserDetection;

namespace HeyUrlChallengeCodeDotnet.Controllers
{
    [Route("/")]
    public class UrlsController : Controller
    {
        private readonly ILogger<UrlsController> _logger;
        private static readonly Random getrandom = new Random();
        private readonly IBrowserDetector browserDetector;

        public UrlsController(ILogger<UrlsController> logger, IBrowserDetector browserDetector)
        {
            this.browserDetector = browserDetector;
            _logger = logger;
        }

        public IActionResult Index([FromServices] ApplicationContext db)
        {
            var model = new HomeViewModel();
            model.Urls = db.Urls.ToList();
            model.BaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/";
            model.NewUrl = new();

            return View(model);
        }

        [Route("/{url}")]
        public IActionResult Visit(string url
            ,[FromServices] ApplicationContext db) {
            //var aa = new OkObjectResult($"{url}, {this.browserDetector.Browser.OS}, {this.browserDetector.Browser.Name}");

            try
            {
                var urlDB = db.Urls.FirstOrDefault(u => u.OriginalUrl == url);

                if (urlDB == null) return NotFound();

                //Update URLs
                urlDB.Count++;
                db.Urls.Update(urlDB);
                db.SaveChanges();

                //Insert Click Information
                var newClick = new Click() {
                    IdUrl = urlDB.Id,
                    OS = browserDetector.Browser.OS,
                    Browser = browserDetector.Browser.Name
                };

                db.Clicks.Add(newClick);
                db.SaveChanges();
                Redirect(url);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                //return StatusCode(500, new ErrorViewModel("RequesID", Message.ERRO_INTERNAL_SERVER_FAILURE));
            }

         }

        [Route("urls/{url}")]
        public IActionResult Show(string url
            , [FromServices] ApplicationContext db)
        {
            var urlDB = db.Urls
                .Include(u => u.Clicks)
                .SingleOrDefault(u => u.ShortUrl == url);

            if (urlDB == null) return NotFound();

            ShowViewModel showViewModel = new ShowViewModel();

            showViewModel.Url = urlDB;
            showViewModel.DailyClicks = db.Clicks
                            .Where(c => c.IdUrl == urlDB.Id)
                            .GroupBy(c => c.CreateAt)
                            .Select(g => new { CreateAt = g.Key, count = g.Count() })
                            .ToDictionary(k => k.CreateAt.ToString("MMMM dd"), i => i.count);

            showViewModel.BrowseClicks = db.Clicks
                            .Where(c => c.IdUrl == urlDB.Id)
                            .GroupBy(c => c.Browser)
                            .Select(g => new { Browser = g.Key, count = g.Count() })
                            .ToDictionary(k => k.Browser, i => i.count);

            showViewModel.PlatformClicks = db.Clicks
                            .Where(c => c.IdUrl == urlDB.Id)
                            .GroupBy(c => c.OS)
                            .Select(g => new { OS = g.Key, count = g.Count() })
                            .ToDictionary(k => k.OS, i => i.count);

            return View(showViewModel);

            //return View(new ShowViewModel
            //            {
            //                        Url = new Url { ShortUrl = url, Count = getrandom.Next(1, 10) },
            //                        DailyClicks = new Dictionary<string, int>
            //                    {
            //                        {"1", 13},
            //                        {"2", 2},
            //                        {"3", 1},
            //                        {"4", 7},
            //                        {"5", 20},
            //                        {"6", 18},
            //                        {"7", 10},
            //                        {"8", 20},
            //                        {"9", 15},
            //                        {"10", 5}
            //                    },
            //                        BrowseClicks = new Dictionary<string, int>
            //                    {
            //                        { "IE", 13 },
            //                        { "Firefox", 22 },
            //                        { "Chrome", 17 },
            //                        { "Safari", 7 },
            //                    },
            //                        PlatformClicks = new Dictionary<string, int>
            //                    {
            //                        { "Windows", 13 },
            //                        { "macOS", 22 },
            //                        { "Ubuntu", 17 },
            //                        { "Other", 7 },
            //                    }
            //            });
         }

        [HttpPost, Route("urls/get-short/{urlOriginal}")]
        public IActionResult GetShort(string urlOriginal
            ,[FromServices] ShortenerService shortenerServiceService
            ,[FromServices] ApplicationContext db)
        {
            string shortCode = shortenerServiceService.GenerateShortCode();

            try
            {
                var urls = db.Urls.ToList();

                if (urls.Exists(uo => uo.OriginalUrl == urlOriginal))
                    return Ok(new { shortCodeGenerated = ShortCode.ALREADY_EXIST_0000 });

                if (urls.Exists(us => us.ShortUrl == shortCode))
                    shortCode = shortenerServiceService.GenerateShortCode();

                var newUrl = new Url() {
                    ShortUrl = shortCode,
                    OriginalUrl = urlOriginal,
                };

                db.Urls.Add(newUrl);
                db.SaveChanges();

                return Ok(new
                {
                    shortCodeGenerated = shortCode
                    //urlOriginal = urlOriginal
                });
            }
            catch(Exception e)
            {
                return StatusCode(500, new ErrorViewModel("RequesID", Message.ERRO_INTERNAL_SERVER_FAILURE));
            }

            //return Json(new { status = "OK", msg = "", token = "ABCD"});
            //throw new Exception("eorrr");
        }


        //private static string GenerateToken(string longUrl)
        //{
        //    string urlsafe = string.Empty;
        //    Enumerable.Range(48, 75).Where(i => i < 58 || i > 64 && i < 91 || i > 96).OrderBy(o => new Random().Next()).ToList().ForEach(i => urlsafe += Convert.ToChar(i));
            
        //    string token = urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6)).ToUpper();
        //    return token;
        //}





    }
}
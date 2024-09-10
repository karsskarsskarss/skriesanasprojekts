using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using mvcprojekts.Data;
using mvcprojekts.Helpers;
using mvcprojekts.Interfaces;
using mvcprojekts.Models;
using mvcprojekts.ViewModels;
using System.Diagnostics;
using System.Globalization;
using System.Net;


namespace mvcprojekts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClubRepository _clubRepository;

        public HomeController(ILogger<HomeController> logger, IClubRepository clubRepository )
        {
            _logger = logger;
            _clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ipInfo = new IPInfo();
            var homeViewModel = new HomeViewModel();
            try
            {
                string url = "https://info.io?token=7944330c70a37a";
                var info = new WebClient().DownloadString(url);
                ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
                homeViewModel.City = ipInfo.City;
                homeViewModel.Region = ipInfo.Region;
                if(homeViewModel.City != null)
                {
                    homeViewModel.Clubs = await _clubRepository.GetClubByCity(homeViewModel.City);
                }
                else
                {
                    homeViewModel.Clubs = null;
                }
                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                homeViewModel.Clubs = null;
            }
            return View(homeViewModel);

           
            
        } 

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Club()
        {
            return View();
        }
        public IActionResult Race()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

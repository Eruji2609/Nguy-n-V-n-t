using AppViews.Models;
using Data.DomainClass;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AppViews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        string seachtext = "####";
        public async Task<IActionResult> Index(string text)
        {
            if(text != null)
            {
                seachtext = text;
            }
            else
            {
                seachtext = "####";
            }
            List<KhachHang> khachHangs = new List<KhachHang>();
            var httpClient = new HttpClient(); //tạo 1 http Client để call API
            var response = await httpClient.GetAsync("https://localhost:7109/api/KhachHang/-get-all-khachHang");
            // Lấy dữ liệu từ file Json - Cài nuget Newtonsoft.json
            // Đọc ra 1 file Json
            string khachHangsResponse = await response.Content.ReadAsStringAsync();
            // Lấy ra list object từ string json
            khachHangs = JsonConvert.DeserializeObject<List<KhachHang>>(khachHangsResponse);
            var data = khachHangs.Where(c => c.Ten.ToLower().Contains(seachtext.ToLower())).Take(1).ToList();
            decimal tongtien = 0;
            if(data.Count > 0)
            {
                foreach (var x in data[0].gioHangChiTiets)
                {
                    tongtien += (x.SoLuong * x.SanPham.Gia);
                }
            }
            
            ViewBag.tongtien= tongtien;
            return View(data);
        }

        public IActionResult Privacy()
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
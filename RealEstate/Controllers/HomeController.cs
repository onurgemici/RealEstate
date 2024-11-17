using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;
using RealEstateData;
using System.Diagnostics;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext context;

        public HomeController(ILogger<HomeController> logger,AppDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = new SelectList(await context.Categories.ToListAsync(), "Id", "Name");
            ViewBag.Districts = new SelectList(await context.Districts.Select(p => new { p.Id, p.Name, ProvinceName = p.Province.Name }).ToListAsync(), "Id", "Name", null, "ProvinceName");
            ViewBag.Latest = await context.Posts.OrderByDescending(p => p.Date).Take(20).ToListAsync();
            return View();
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
        [HttpGet]
        public async Task<IActionResult> GetProvinces()
        {

            var model = await context
                .Province
                .Select(p => new { p.Id, p.Name })
                .ToListAsync();
            return Json(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetDistricts(int id)
        {


            var model = await context
                .Districts
                .Where(p => p.ProvinceId == id)
                .Select(p => new { p.Id, p.Name })
                .ToListAsync();
            return Json(model);
        }

        public async Task<IActionResult> Post(Guid id)
        {
            var post = await context.Posts
                .Include(p => p.Category)  // Kategoriyi dahil et
                .Include(p => p.District)  // İl/ilçe bilgisini dahil et
                .Include(p => p.Specifications) // Özellikleri dahil et
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            // Kullanıcı bilgilerini almak için UserId'yi kullan
            var user = await context.Users
                .Where(u => u.Id == post.UserId)
                .FirstOrDefaultAsync();

            var postViewModel = new PostViewModel
            {
                Id = post.Id,
                UserId = post.UserId,
                DistrictId = post.DistrictId,
                CategoryId = post.CategoryId,
                Name = post.Name,
                Image = post.Image,
                Descriptions = post.Descriptions,
                Price = post.Price,
                Date = post.Date,
                Latitude = post.Latitude,
                Longitude = post.Longitude,
                Type = (PostTypesView)post.Type, // PostType'ı enum'a dönüştür
                SpecificationNames = post.Specifications?.Select(s => s.Name).ToList() ?? new List<string>(), // Null kontrolü yaparak boş liste ata
                CategoryName = post.Category?.Name, // Kategorinin adını al
                DistrictName = post.District?.Name, // İl/ilçenin adını al
                ProvinceName = post.District?.Province?.Name,  // İl ismini al
                UserName = user?.Name, // Kullanıcı adını al
                PhoneNumber = user?.PhoneNumber // Telefon numarasını al
            };

            return View(postViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Search(SearchViewModel model)
        {await PopulateDropdowns();
            var result = await context
                .Posts
                .Where(p =>
                (p.DistrictId == model.DistrictId || model.DistrictId == null) &&
                (p.Price >= model.MinPrice || model.MinPrice == null) &&
                (p.Price <= model.MaxPrice || model.MaxPrice == null) &&
                (p.CategoryId == model.CategoryId || model.CategoryId == null) &&
                (p.Type == model.PostType || model.PostType == null)
                )
                .ToListAsync();
            ViewBag.SearchModel = model;
            return View(result);
        }
        private async Task PopulateDropdowns()
        {
            ViewBag.Categories = new SelectList(await context.Categories.ToListAsync(), "Id", "Name");
            ViewBag.Districts = new SelectList(await context.Districts.Select(p => new { p.Id, p.Name, ProvinceName = p.Province.Name }).ToListAsync(), "Id", "Name", null, "ProvinceName");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RR_MVC.Models.RatingsVM;
using RR_MVC.RestaurantRaterServices.Contracts;

namespace RR_MVC.Controllers
{
    [Route("[controller]")]
    public class Ratingcontroller : Controller
    {
        private IRatingService _service;

        public Ratingcontroller(IRatingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetRatings());
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var restaurantOptions = await _service.SelectListItemConversion();

            Ratings_CreateVM rCreate = new Ratings_CreateVM();
            rCreate.RestaurantOptions = restaurantOptions;

            return View(rCreate);
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ratings_CreateVM model)
        {
            if (!ModelState.IsValid) return View(model);
            if (await _service.AddRating(model))
                return RedirectToAction(nameof(Index));
            else
                return RedirectToAction(nameof(Error));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
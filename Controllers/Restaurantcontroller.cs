using Microsoft.AspNetCore.Mvc;
using RR_MVC.Models.RestaurantVM;
using RR_MVC.RestaurantRaterServices.Contracts;

namespace RR_MVC.Controllers
{
    [Route("[controller]")]
    public class Restaurantcontroller : Controller
    {
        private IRestaurantService _restService;

        public Restaurantcontroller(IRestaurantService restService)
        {
            _restService = restService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Restaurant_ListItemVM> restaurants = await _restService.GetRestaurants();
            return View(restaurants);
        }

        [HttpGet]  //This is where we "Get" our empty form...
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Restaurant_CreateVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _restService.CreateRestaurant(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<IActionResult> Restaurant(int id)
        {
            return View(await _restService.GetRestaurant(id));
        }

        [HttpGet("Edit/{restaurantId}")]
        public async Task<IActionResult> Edit(int restaurantId)
        {
            //I want edit form to populate previous data
            var restInDb = await _restService.GetRestaurant(restaurantId);

            // the VM -> Restaurant_EditVM so that's what we need to pass into the View().
            Restaurant_EditVM rest_VM = new Restaurant_EditVM
            {
                Id = restInDb.Id,
                Name = restInDb.Name,
                Location = restInDb.Location
            };

            return View(rest_VM);
        }

        [HttpPost("Edit/{restaurantId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int restaurantId, Restaurant_EditVM model)
        {
            if (!ModelState.IsValid) return View(model);

            model.Id = restaurantId;
            if (await _restService.UpdateRestaurant(model))
                return RedirectToAction("Details", new { id = restaurantId });
            else
                return RedirectToAction(nameof(Error));
        }

        [HttpGet("Delete/{restaurantId}")]
        public async Task<IActionResult> Delete(int? restaurantId)
        {
            if (restaurantId == null)
                return RedirectToAction(nameof(Index));

            //I want edit form to populate previous data
            var restInDb = await _restService.GetRestaurant(restaurantId.Value);

            if (restInDb != null)
            {
                var restDetail = new Restaurant_DetailVM
                {
                    Id = restInDb.Id,
                    Name = restInDb.Name,
                    Location = restInDb.Location,
                    Score = restInDb.Score
                };

                return View(restDetail);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("Delete/{restaurantId}")]
        public async Task<IActionResult> Delete(int restaurantId)
        {
            if (await _restService.DeleteRestaurant(restaurantId))
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
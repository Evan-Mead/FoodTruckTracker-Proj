using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodTruckTracker.Data;
using FoodTruckTracker.Models;
using System.Security.Claims;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace FoodTruckTracker.Controllers
{
    public class FoodiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Foodies
        public async Task<IActionResult> Index()
        {
            FoodieViewFoodTrucks foodieViewFoodTrucks = new FoodieViewFoodTrucks();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            foodieViewFoodTrucks.Foodie = _context.Foodies.Where(f => f.IdentityUserId == userId).SingleOrDefault();
            var applicationDbContext = _context.Foodies.Include(f => f.IdentityUser);
            foodieViewFoodTrucks.FoodTrucks = _context.FoodTrucks.ToList();
            return View(foodieViewFoodTrucks);
        }

        // POST: Foodies
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(FoodieViewFoodTrucks foodieViewFoodTrucks)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            foodieViewFoodTrucks.Foodie = _context.Foodies.Where(f => f.IdentityUserId == userId).SingleOrDefault();
            var applicationDbContext = _context.Foodies.Include(f => f.IdentityUser);
            foodieViewFoodTrucks.FoodTrucks = _context.FoodTrucks.ToList();
            return View(foodieViewFoodTrucks);
        }

        // GET: Foodies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodie = await _context.Foodies
                .Include(f => f.IdentityUser)
                .FirstOrDefaultAsync(m => m.FoodieId == id);
            if (foodie == null)
            {
                return NotFound();
            }

            return View(foodie);
        }

        // GET: Foodies/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Foodies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodieId,FoodieName,IdentityUserId")] Foodie foodie)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                foodie.IdentityUserId = userId;
                _context.Add(foodie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", foodie.IdentityUserId);
            return View(foodie);
        }

        // GET: Foodies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodie = await _context.Foodies.FindAsync(id);
            if (foodie == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", foodie.IdentityUserId);
            return View(foodie);
        }

        // POST: Foodies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodieId,FoodieName,IdentityUserId")] Foodie foodie)
        {
            if (id != foodie.FoodieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodieExists(foodie.FoodieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", foodie.IdentityUserId);
            return View(foodie);
        }

        // GET: Foodies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodie = await _context.Foodies
                .Include(f => f.IdentityUser)
                .FirstOrDefaultAsync(m => m.FoodieId == id);
            if (foodie == null)
            {
                return NotFound();
            }

            return View(foodie);
        }

        // POST: Foodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodie = await _context.Foodies.FindAsync(id);
            _context.Foodies.Remove(foodie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodieExists(int id)
        {
            return _context.Foodies.Any(e => e.FoodieId == id);
        }

        public IActionResult CreateReview(int foodTruckId)
        {
            ViewBag.FoodTruckId = foodTruckId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(Review review)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                FoodTruck foodTruck = _context.FoodTrucks.Where(f => f.IdentityUserId == userId).SingleOrDefault();
                review.FoodTruckId = foodTruck.FoodTruckId;

                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:44312/foodtrucktracker/reviews", content)) ;
                }
                return RedirectToAction("ViewReviews", new { foodTruckId = review.FoodTruckId });
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> ViewReviews(int foodTruckId)
        {
            ViewBag.FoodTruckId = foodTruckId;
            List<Review> foodTruckReviews = new List<Review>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44312/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));
                ViewBag.country = "";
                HttpResponseMessage response = await client.GetAsync("http://localhost:44312/foodtrucktracker/reviews");

                if (response.IsSuccessStatusCode)
                {
                    var details = await response.Content.ReadAsAsync<IEnumerable<Review>>();
                    foreach(Review review in details)
                    {
                        if (review.FoodTruckId == foodTruckId)
                        {
                            foodTruckReviews.Add(review);
                        }
                    }
                    return View(foodTruckReviews);
                }
                else
                {
                    return View();
                }
            }
        }
    }
}

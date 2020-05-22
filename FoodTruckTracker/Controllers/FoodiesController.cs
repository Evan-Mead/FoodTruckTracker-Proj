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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foodie = _context.Foodies.Where(f => f.IdentityUserId == userId).SingleOrDefault();
            var applicationDbContext = _context.Foodies.Include(f => f.IdentityUser);
            return View(foodie);
        }

        // POST: Foodies
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(FoodieViewFoodTrucks foodieViewFoodTrucks)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foodie = _context.Foodies.Where(f => f.IdentityUserId == userId).SingleOrDefault();
            var applicationDbContext = _context.Foodies.Include(f => f.IdentityUser);
            return View(foodie);
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
    }
}

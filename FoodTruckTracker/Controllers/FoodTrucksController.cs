using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using FoodTruckTracker.Data;
using FoodTruckTracker.Models;
using System.Security.Claims;

namespace FoodTruckTracker.Controllers
{
    public class FoodTrucksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodTrucksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodTrucks
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foodTruck = _context.FoodTrucks.Where(f => f.IdentityUserId == userId).SingleOrDefault();
            var applicationDbContext = _context.FoodTrucks.Include(f => f.IdentityUser);
            return View(foodTruck);
        }

        // GET: FoodTrucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTrucks
                .Include(f => f.IdentityUser)
                .FirstOrDefaultAsync(m => m.FoodTruckId == id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            return View(foodTruck);
        }

        // GET: FoodTrucks/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: FoodTrucks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodTruckId,FoodTruckName,IdentityUserId")] FoodTruck foodTruck)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                foodTruck.IdentityUserId = userId;
                _context.Add(foodTruck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", foodTruck.IdentityUserId);
            return View(foodTruck);
        }

        // GET: FoodTrucks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTrucks.FindAsync(id);
            if (foodTruck == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", foodTruck.IdentityUserId);
            return View(foodTruck);
        }

        // POST: FoodTrucks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodTruckId,FoodTruckName,IdentityUserId")] FoodTruck foodTruck)
        {
            if (id != foodTruck.FoodTruckId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodTruck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodTruckExists(foodTruck.FoodTruckId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", foodTruck.IdentityUserId);
            return View(foodTruck);
        }

        // GET: FoodTrucks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTrucks
                .Include(f => f.IdentityUser)
                .FirstOrDefaultAsync(m => m.FoodTruckId == id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            return View(foodTruck);
        }

        // POST: FoodTrucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodTruck = await _context.FoodTrucks.FindAsync(id);
            _context.FoodTrucks.Remove(foodTruck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodTruckExists(int id)
        {
            return _context.FoodTrucks.Any(e => e.FoodTruckId == id);
        }
    }
}

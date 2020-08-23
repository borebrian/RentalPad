using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fuela.DBContext;
using RentalPad.Models;

namespace RentalPad.Controllers
{
    public class Rental_OwnersController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Rental_OwnersController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Rental_Owners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rental_owners.ToListAsync());
        }

        // GET: Rental_Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental_Owners = await _context.Rental_owners
                .FirstOrDefaultAsync(m => m.National_id == id);
            if (rental_Owners == null)
            {
                return NotFound();
            }

            return View(rental_Owners);
        }

        // GET: Rental_Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rental_Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("National_id,Full_names,Phone_number,Location")] Rental_Owners rental_Owners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rental_Owners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rental_Owners);
        }

        // GET: Rental_Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental_Owners = await _context.Rental_owners.FindAsync(id);
            if (rental_Owners == null)
            {
                return NotFound();
            }
            return View(rental_Owners);
        }

        // POST: Rental_Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("National_id,Full_names,Phone_number,Location")] Rental_Owners rental_Owners)
        {
            if (id != rental_Owners.National_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rental_Owners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Rental_OwnersExists(rental_Owners.National_id))
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
            return View(rental_Owners);
        }

        // GET: Rental_Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental_Owners = await _context.Rental_owners
                .FirstOrDefaultAsync(m => m.National_id == id);
            if (rental_Owners == null)
            {
                return NotFound();
            }

            return View(rental_Owners);
        }

        // POST: Rental_Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rental_Owners = await _context.Rental_owners.FindAsync(id);
            _context.Rental_owners.Remove(rental_Owners);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Rental_OwnersExists(int id)
        {
            return _context.Rental_owners.Any(e => e.National_id == id);
        }
    }
}

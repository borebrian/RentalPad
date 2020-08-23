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
    public class Rooms_regController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Rooms_regController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Rooms_reg
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rooms_reg.ToListAsync());
        }

        // GET: Rooms_reg/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rooms_reg = await _context.Rooms_reg
                .FirstOrDefaultAsync(m => m.Room_number == id);
            if (rooms_reg == null)
            {
                return NotFound();
            }

            return View(rooms_reg);
        }

        // GET: Rooms_reg/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms_reg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rental_reg,Room_number,Room_category")] Rooms_reg rooms_reg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rooms_reg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rooms_reg);
        }

        // GET: Rooms_reg/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rooms_reg = await _context.Rooms_reg.FindAsync(id);
            if (rooms_reg == null)
            {
                return NotFound();
            }
            return View(rooms_reg);
        }

        // POST: Rooms_reg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Rental_reg,Room_number,Room_category")] Rooms_reg rooms_reg)
        {
            if (id != rooms_reg.Room_number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rooms_reg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Rooms_regExists(rooms_reg.Room_number))
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
            return View(rooms_reg);
        }

        // GET: Rooms_reg/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rooms_reg = await _context.Rooms_reg
                .FirstOrDefaultAsync(m => m.Room_number == id);
            if (rooms_reg == null)
            {
                return NotFound();
            }

            return View(rooms_reg);
        }

        // POST: Rooms_reg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rooms_reg = await _context.Rooms_reg.FindAsync(id);
            _context.Rooms_reg.Remove(rooms_reg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Rooms_regExists(string id)
        {
            return _context.Rooms_reg.Any(e => e.Room_number == id);
        }
    }
}

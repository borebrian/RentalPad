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
    public class Room_CategoryController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Room_CategoryController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Room_Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.Room_Category.ToListAsync());
        }

        // GET: Room_Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Category = await _context.Room_Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room_Category == null)
            {
                return NotFound();
            }

            return View(room_Category);
        }

        // GET: Room_Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room_Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category,Rent_Ammount")] Room_Category room_Category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room_Category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room_Category);
        }

        // GET: Room_Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Category = await _context.Room_Category.FindAsync(id);
            if (room_Category == null)
            {
                return NotFound();
            }
            return View(room_Category);
        }

        // POST: Room_Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category,Rent_Ammount")] Room_Category room_Category)
        {
            if (id != room_Category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room_Category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Room_CategoryExists(room_Category.Id))
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
            return View(room_Category);
        }

        // GET: Room_Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Category = await _context.Room_Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room_Category == null)
            {
                return NotFound();
            }

            return View(room_Category);
        }

        // POST: Room_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room_Category = await _context.Room_Category.FindAsync(id);
            _context.Room_Category.Remove(room_Category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Room_CategoryExists(int id)
        {
            return _context.Room_Category.Any(e => e.Id == id);
        }
    }
}

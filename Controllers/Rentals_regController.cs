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
    public class Rentals_regController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Rentals_regController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Rentals_reg
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rentals_reg.ToListAsync());
        }

        // GET: Rentals_reg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentals_reg = await _context.Rentals_reg
                .FirstOrDefaultAsync(m => m.id == id);
            if (rentals_reg == null)
            {
                return NotFound();
            }

            return View(rentals_reg);
        }

        // GET: Rentals_reg/Create
        public IActionResult Create(Rental_Owners rental_Owners)
        {
            int selectedValue = rental_Owners.National_id;
            List<Rental_Owners> idList = new List<Models.Rental_Owners>();
            idList = (from product in _context.Rental_owners select product).ToList();
            //idList.Insert(0, new Rental_Owners { National_id=0,Full_names})

            idList.Insert(0, new Rental_Owners { National_id = 0, Full_names = "--Select National ID--" });
            ViewBag.IDlist = idList;
            return View();
        }

        // POST: Rentals_reg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,National_id,R_name,R_location,No_rooms")] Rentals_reg rentals_reg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentals_reg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentals_reg);
        }

        // GET: Rentals_reg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentals_reg = await _context.Rentals_reg.FindAsync(id);
            if (rentals_reg == null)
            {
                return NotFound();
            }
            return View(rentals_reg);
        }

        // POST: Rentals_reg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,National_id,R_name,R_location,No_rooms")] Rentals_reg rentals_reg)
        {
            if (id != rentals_reg.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentals_reg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Rentals_regExists(rentals_reg.id))
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
            return View(rentals_reg);
        }

        // GET: Rentals_reg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentals_reg = await _context.Rentals_reg
                .FirstOrDefaultAsync(m => m.id == id);
            if (rentals_reg == null)
            {
                return NotFound();
            }

            return View(rentals_reg);
        }

        // POST: Rentals_reg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentals_reg = await _context.Rentals_reg.FindAsync(id);
            _context.Rentals_reg.Remove(rentals_reg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Rentals_regExists(int id)
        {
            return _context.Rentals_reg.Any(e => e.id == id);
        }
    }
}
